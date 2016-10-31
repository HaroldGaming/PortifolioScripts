using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Areas : MonoBehaviour {

    public SpawnManager spawnManager;
    public int newRoundAmount;
    private int counter;

    public List<GameObject> aditionalAreaList = new List<GameObject>();

	void Start () {
        counter = 0;
	}
	
	void Update () {

	}

    void CheckForEnd() {
        if(counter == aditionalAreaList.Count) {
            //add end level screen
            Time.timeScale = 0;
            print("end");
        }
    }

    public void CheckForRound() {
        if (spawnManager.waveCount == newRoundAmount) {
            CheckForEnd();
            aditionalAreaList[counter].SetActive(true);
            counter++;
        }
    }
}
