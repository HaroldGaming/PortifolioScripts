using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTileSpawner : MonoBehaviour { 

    public List<GameObject> spawnPointList = new List<GameObject>();
    private bool isExitRoom = false;

    void Start(){//adds all the chil objects to a list, so it can be accesed later
        int children = transform.childCount;
        for (int i = 0; i < children; ++i) {
            spawnPointList.Add(transform.GetChild(i).gameObject);
        }           
    }

    public void SpawnExit(GameObject exit) {//spawns the exit
        var temp = Instantiate(exit, spawnPointList[spawnPointList.Count-1].transform.position, Quaternion.identity);
        temp.transform.parent = gameObject.transform;
        isExitRoom = true;
    }

    public void Spawner(GameObject objectToSpawn, int spawner) {// spawns the given objects if the room is not the exit
        if (!isExitRoom) {
            var temp = Instantiate(objectToSpawn, spawnPointList[spawner].transform.position, Quaternion.identity);
            temp.transform.parent = gameObject.transform;
        }
    }
}
