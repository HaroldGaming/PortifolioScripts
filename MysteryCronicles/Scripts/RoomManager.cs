using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public Transform[] roomList; // List with all the trigger fields
    public int enemylevel0Enemypercentile, enemylevel1Enemypercentile; // % of enemies that need to spawn for each level

    [HideInInspector]
    public int levelNumber;  

    // Ads itself to all the room triggers, so they can call upon this class
    private void Start() {

        // Sets the level number
        levelNumber = FindObjectOfType<MenuManager>().tempLevel;

        // Adds the RoomManager to each trigger and sets the amount of enemies that needs to be spawn.
        for (int i = 0; i < roomList.Length; i++) {
            roomList[i].GetComponent<RoomTrigger>().roomManager = this;
            roomList[i].GetComponent<RoomTrigger>().SetEnemies();
        }
    }

    // Activates the spawn function on all the enemies in the given room.
    public void SpawnEnemies(int roomNumber, int spawnAmount) {
        int temp = 0;

        // Checks how many enemies that needs to be spawns, then it activates one of the childeren to spawn until all needed enemies have been spawned.
        foreach(Transform child in roomList[roomNumber]) {
            StartCoroutine(child.GetComponent<Enemy01>().Spawn());
            roomList[roomNumber].GetComponent<RoomTrigger>().enemyNumber++;
            temp++;

            if(temp == spawnAmount) {
                break;
            }
        }       
    }
}
