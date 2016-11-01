using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour {

    private GameObject[] levelPicks;
    private GameObject[] triggerHits;
    private GameObject[] lanterns;
    private GameObject[] difficultyNumber;
    public GameObject spawnPlatform;
    private GameObject currentLevel;
    private GameObject shopLevel, itemLevel, afterSpecialLevel, startLevel;
    private Vector3 spawnPosition;
    public GameObject levelManager;
    private LevelRandomizer randomLevelMizer;
    public int blockCounter, levelCounter, maxBlockAmount;
    public int randomNumLevel, randomNumShop;
    public int shopChance;



    void Start() {
        blockCounter = 1;
        maxBlockAmount = Random.Range(4, 6);
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        randomLevelMizer = levelManager.GetComponent<LevelRandomizer>();
        currentLevel = Instantiate(startLevel, new Vector3(0, 0, 0), transform.rotation) as GameObject;
        randomLevelMizer.PickRandomLevel();
    }

    public void AddObjects() {
        lanterns[0] = GameObject.FindGameObjectWithTag("lantern1");
        lanterns[1] = GameObject.FindGameObjectWithTag("lantern2");
        lanterns[2] = GameObject.FindGameObjectWithTag("lantern3");
        RandomAdd();
    }

    void RandomAdd() {
        randomNumLevel = Random.Range(0, 2);

        triggerHits[0] = levelPicks[randomNumLevel];

        if (randomNumLevel == 0) {
            triggerHits[1] = levelPicks[1];
            triggerHits[2] = levelPicks[2];
        }

        if (randomNumLevel == 1) {
            triggerHits[1] = levelPicks[0];
            triggerHits[2] = levelPicks[2];
        }

        if (randomNumLevel == 2) {
            triggerHits[1] = levelPicks[0];
            triggerHits[2] = levelPicks[1];
        }

        LanternColor();
    }

    void LanternColor() {
        for (int i = 0; i < 3; i++) {
            if (triggerHits[i].tag == "easy") {
                lanterns[i].GetComponent<DifficultyCube>().difficultyNumber = 0;
            }
            if (triggerHits[i].tag == "medium") {
                lanterns[i].GetComponent<DifficultyCube>().difficultyNumber = 1;
            }
            if (triggerHits[i].tag == "hard") {
                lanterns[i].GetComponent<DifficultyCube>().difficultyNumber = 2;
            }
        }

    }


    void BuildNew(int number) {
        print(number);
        blockCounter++;
        GameObject tempLevel = currentLevel;
        Destroy(currentLevel);
        currentLevel = null;
        if (blockCounter == 3) {
            afterSpecialLevel = triggerHits[number];
            currentLevel = Instantiate(itemLevel, new Vector3(0, 0, 0), tempLevel.transform.rotation) as GameObject;
        }
        else {
            if (blockCounter == 4) {
                randomNumShop = Random.Range(0, 100);
                if (randomNumShop <= shopChance) {
                    afterSpecialLevel = triggerHits[number];
                    currentLevel = Instantiate(shopLevel, new Vector3(0, 0, 0), tempLevel.transform.rotation) as GameObject;
                }
                else {
                    currentLevel = Instantiate(triggerHits[number], new Vector3(0, 0, 0), tempLevel.transform.rotation) as GameObject;

                }
            }
            else {
                currentLevel = Instantiate(triggerHits[number], new Vector3(0, 0, 0), tempLevel.transform.rotation) as GameObject;
            }
        }

    }

    void SetSpawn() {
        spawnPlatform = GameObject.FindGameObjectWithTag("spawnplatform");
        spawnPosition = spawnPlatform.transform.position;
        spawnPosition.y += 3;
    }

    void CheckForNewLevel() {
        if (blockCounter > maxBlockAmount) {
            levelCounter++;
            if(levelCounter == 3) {
                levelCounter = 0;
            }
            blockCounter = 0;
            maxBlockAmount = Random.Range(4, 6);
        }
    }
    void OnCollisionEnter(Collision hit) {
        if (hit.transform.tag == "trigger1") {
            CheckForNewLevel();
            BuildNew(0);
            SetSpawn();
            transform.position = spawnPosition;
            randomLevelMizer.PickRandomLevel();
        }

        if (hit.transform.tag == "trigger2") {
            CheckForNewLevel();
            BuildNew(1);
            SetSpawn();
            transform.position = spawnPosition;
            randomLevelMizer.PickRandomLevel();
        }

        if (hit.transform.tag == "trigger3") {
            CheckForNewLevel();
            BuildNew(2);
            SetSpawn();
            transform.position = spawnPosition;
            randomLevelMizer.PickRandomLevel();
        }

        if (hit.transform.tag == "triggerX") {
            Destroy(currentLevel);
            currentLevel = Instantiate(afterSpecialLevel, new Vector3(0, 0, 0), currentLevel.transform.rotation) as GameObject;
            SetSpawn();
            transform.position = spawnPosition;
            randomLevelMizer.PickRandomLevel();
        }
    }
}
