using UnityEngine;
using System.Collections;

public class LevelRandomizer : MonoBehaviour {

    private int randomNum;
    public GameObject[] levelListEasy, levelListMedium, levelListHard, level2ListEasy, level2ListMedium, level2ListHard, level3ListEasy, level3ListMedium, level3ListHard;
    private LevelSpawner levelSpawner;
    public GameObject player;

    void Start() {
        
    }

    void Update() {

    }

    public void PickRandomLevel() {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        levelSpawner = player.GetComponent<LevelSpawner>();

        switch (levelSpawner.levelCounter) {
            case 0:
                print("Picked");
                levelSpawner.levelPicks[0] = levelListEasy[0];

                levelSpawner.levelPicks[1] = levelListMedium[0];

                levelSpawner.levelPicks[2] = levelListHard[0];
                break;

            case 1:
                levelSpawner.levelPicks[0] = level2ListEasy[0];

                levelSpawner.levelPicks[1] = level2ListMedium[0];

                levelSpawner.levelPicks[2] = level2ListHard[0];
                break;

            case 2:
                levelSpawner.levelPicks[0] = level3ListEasy[0];
;
                levelSpawner.levelPicks[1] = level3ListMedium[0];

                levelSpawner.levelPicks[2] = level3ListHard[0];
                break;
        }

        levelSpawner.AddObjects();
    }
}
