//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour {

	public GameObject[] levelPicks;
	public GameObject[] triggerHits;
	public GameObject[] lanterns;
	public GameObject[] difficultyNumber;
	public GameObject spawnPlatform;
	public GameObject currentLevel;
	public GameObject shopLevel, itemLevel, afterSpecialLevel, startLevel, afterStartLevel;
	public GameObject player;
	public Vector3 spawnPosition;
	public LevelRandomizer randomLevelMizer;
	public int blockCounter, levelCounter, maxBlockAmount;
	public int randomNumLevel, randomNumShop;
	public int shopChance;



	void Start () {
		blockCounter = 1;
		maxBlockAmount = Random.Range(4,6);
		randomLevelMizer = GetComponent<LevelRandomizer>();
		currentLevel = Instantiate(startLevel, new Vector3(0,0,0), transform.rotation) as GameObject;
		SetSpawn();
		StartCoroutine(SetLevel());
		if(player.GetComponent<TutorialCheck>().tutorialOn == true){
			afterSpecialLevel = afterStartLevel;
			player.GetComponent<TutorialCheck>().tutorialOn = false;
		}
	}

	public void AddObjects(){
		lanterns[0] = GameObject.FindGameObjectWithTag("lantern1");
		lanterns[1] = GameObject.FindGameObjectWithTag("lantern2");
		lanterns[2] = GameObject.FindGameObjectWithTag("lantern3");
		RandomAdd();
	}

	void RandomAdd(){
		randomNumLevel = Random.Range(0,2);

		triggerHits[0] = levelPicks[randomNumLevel];

		if(randomNumLevel == 0){
			triggerHits[1] = levelPicks[1];
			triggerHits[2] = levelPicks[2];
		}

		if(randomNumLevel == 1){
			triggerHits[1] = levelPicks[0];
			triggerHits[2] = levelPicks[2];
		}

		if(randomNumLevel == 2){
			triggerHits[1] = levelPicks[0];
			triggerHits[2] = levelPicks[1];
		}
			
		LanternColorer();
	}

	void LanternColorer(){
		for(int i = 0; i < triggerHits.Length; i++){
			if(triggerHits[i].tag == "easy"){
				lanterns[i].transform.FindChild("GreenFire").gameObject.SetActive(true);
			}
			if(triggerHits[i].tag == "medium"){
				lanterns[i].transform.FindChild("BlueFire").gameObject.SetActive(true);
			}
			if(triggerHits[i].tag == "hard"){
				lanterns[i].transform.FindChild("RedFire").gameObject.SetActive(true);
			}
		}

	}

	void BuildNew(int number){
		print(number);
		blockCounter++;
		GameObject tempLevel = currentLevel;
		Destroy(currentLevel);
		currentLevel = null;

		if(player.GetComponent<TutorialCheck>().dropPodOn < 1){
			GameObject.FindGameObjectWithTag("DropPod").SetActive (true);
			player.GetComponent<TutorialCheck>().dropPodOn++;
		}

		if(blockCounter == 3){
			afterSpecialLevel = triggerHits[number];
			currentLevel = Instantiate(itemLevel, new Vector3(0,0,0),  tempLevel.transform.rotation) as GameObject;
		}
		else{
			if(blockCounter == 4){
				randomNumShop = Random.Range(0, 100);
				if(randomNumShop <= shopChance){
					afterSpecialLevel = triggerHits[number];
					currentLevel = Instantiate(shopLevel, new Vector3(0,0,0), tempLevel.transform.rotation) as GameObject;
				}
				else{
					currentLevel = Instantiate(triggerHits[number], new Vector3(0,0,0),  tempLevel.transform.rotation) as GameObject;

				}
			}
			else{
				currentLevel = Instantiate(triggerHits[number], new Vector3(0,0,0),  tempLevel.transform.rotation) as GameObject;
			}
		}

	}

	void SetSpawn(){
		spawnPlatform =  GameObject.FindGameObjectWithTag("spawnplatform");
		spawnPosition = spawnPlatform.transform.position;
		spawnPosition.y+= 3;
	}

	void CheckForNewLevel(){
		if(blockCounter > maxBlockAmount){
			levelCounter++;
			blockCounter = 0;
			maxBlockAmount = Random.Range(4,6);
		}
	}

	public void TriggerDetect (int twister){

		switch (twister){

		case 1:
			CheckForNewLevel();
			BuildNew(0);
			SetSpawn();
			player.transform.position = spawnPosition;
			randomLevelMizer.PickRandomLevel();
		break;

		case 2:
			CheckForNewLevel();
			BuildNew(1);
			SetSpawn();
			player.transform.position = spawnPosition;
			randomLevelMizer.PickRandomLevel();
		break;

		case 3:
			CheckForNewLevel();
			BuildNew(2);
			SetSpawn();
			player.transform.position = spawnPosition;
			randomLevelMizer.PickRandomLevel();
		break;

		case 4:
			Destroy(currentLevel);
			currentLevel = Instantiate(afterSpecialLevel, new Vector3(0,0,0),  currentLevel.transform.rotation) as GameObject;
			SetSpawn();
			player.transform.position = spawnPosition;
			randomLevelMizer.PickRandomLevel();
		break;

		}
	}

	public IEnumerator SetLevel (){

		yield return new WaitForEndOfFrame ();

			randomLevelMizer.PickRandomLevel();
			player = GameObject.FindGameObjectWithTag("Player");

	}
}
