using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
 

    public List<GameObject> rooms;

    public float exitWaitTime;
    private bool spawnedExit;
    //public GameObject boss;

    private void Update() {//wait x amount of time to make sure that everything has a change to spawn, then it will asign the exit room and disable itself for performence
        if(exitWaitTime <= 0 && spawnedExit == false) {
            for(int i = 0; i < rooms.Count; i++) {
                if( i== rooms.Count - 1) {
                    Debug.Log(rooms[i].transform + "is the exit room");                  
                    GetComponent<SpawnManager>().StartSpawning(rooms[i]);
                    spawnedExit = true;
                    enabled = false;
                }
            }
        }
        else {
            exitWaitTime -= Time.deltaTime;
        }
    }

}
