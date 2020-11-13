using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int spawnRngRange;

    public GameObject[] level1EnemyList;
    public GameObject[] level1LootList;
    public GameObject exitObject;
    public List<GameObject> inTileSpawnersList = new List<GameObject>();

    public void StartSpawning(GameObject exitRoom) { //call this to start the spawning proces
        SpawnExit(exitRoom);
        AddSpawners();

        for (int i = 0; i < inTileSpawnersList.Count; i++) {
            InTileSpawner spawner = inTileSpawnersList[i].GetComponent<InTileSpawner>();
            for (int ii = 0; ii < spawner.spawnPointList.Count; ii++) {//Checking for all the spawn points in each room and spawn acorindgly.
                int rdm = Random.Range(1, spawnRngRange);//picks a random numb to either spawna enemy, loot or nothing.
                //print(rdm);
                if (rdm == 1) {
                    int randomEnemyNum = Random.Range(0, level1EnemyList.Length);
                    spawner.Spawner(level1EnemyList[randomEnemyNum], ii);
                }

                if (rdm == 2) {
                    int randomLootNum = Random.Range(0, level1LootList.Length);
                    spawner.Spawner(level1LootList[randomLootNum],ii);
                }

            }
                

        }
    }


    void SpawnExit(GameObject exitRoom) {//spawns the exit if this is the exit room
        Transform t = exitRoom.transform;
        foreach (Transform tr in t) {
            if (tr.tag == "tilemanager") {
                tr.GetComponent<InTileSpawner>().SpawnExit(exitObject);
            }
        }

    }

    void AddSpawners() {
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("tilemanager")) {//Instead of manually adding it searches and the objects with the tagg.
            inTileSpawnersList.Add(tile);
        }
    }
}
