using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour {

    public RoomManager roomManager;
    [SerializeField]
    private int roomNumber; // Number of the room the trigger is in
    [SerializeField]
    private float doorMoveAmount, doorMoveTime; // The amount and the time it takes for the door to move
    [SerializeField]
    private bool isFinalRoom, isSplitRoom; // Bool to check if the room is a split, final room or normal room.
    [SerializeField]
    private Transform doorEntranceObject; // This is the door thats going to close
    [SerializeField]
    private Transform doorExitObject; // This is the door thats going to open
    [SerializeField]
    private Transform doorSplitLevel1, doorSplitLevel2; // These are the door for the splitrooms

    private float enemiesLevel0Amount, enemiesLevel1Amount, maxEnemyAmount;
    [HideInInspector]
    public int enemyNumber;

    // If the player walks trough this trigger it will close the door behind him/her and will start spawning the enemies     
    private void OnTriggerEnter(Collider other) {

        // Checks if the object that walked trough the trigger is the player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.tag == "Player") {
            StartCoroutine(MoveDoor(doorEntranceObject, true));

            // Check which room the player is in
            if (isFinalRoom) {
                roomManager.SpawnEnemies(roomNumber, (int)maxEnemyAmount);
            }
            else {

                // Spawns the right amount of enemies for the room
                switch (roomManager.levelNumber) {
                    case 0:
                        roomManager.SpawnEnemies(roomNumber, (int)enemiesLevel0Amount);
                        break;
                    case 1:
                        roomManager.SpawnEnemies(roomNumber, (int)enemiesLevel1Amount);
                        break;
                    case 2:
                        roomManager.SpawnEnemies(roomNumber, (int)maxEnemyAmount);
                        break;
                }
            }

            // Gets every child in the trigger
            foreach (Transform child in transform) {

                // Gives the enemies their player target
                child.GetComponent<Enemy01>().playerTarget = other.gameObject;
                child.GetComponent<Enemy01>().roomTrigger = GetComponent<RoomTrigger>();
            }
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Sets the right amount of enemies that need to spawn in the room.
    public void SetEnemies() {

        // Sets max enemies to 0
        maxEnemyAmount = 0;

        foreach (Transform child in transform) {

            // Checks how many enemies can exist in the room
            maxEnemyAmount++;
        }

        // Sets the right amount of enemies for the room based on the level
        enemiesLevel0Amount = maxEnemyAmount / 100 * roomManager.enemylevel0Enemypercentile;
        enemiesLevel1Amount = maxEnemyAmount / 100 * roomManager.enemylevel1Enemypercentile;
    }

    // This function is called upon everytime a enemy in the room dies. if all enemies are dead depending on the room and level a certain door will open.
    public void EnemyCheck() {

        // Removes one enemy from the count
        enemyNumber--;

        if(enemyNumber <= 0) {

            // Checks if this is the final room, if so play the story
            if (isFinalRoom) {
                StoryManager storyManager = FindObjectOfType<StoryManager>();
                switch (roomManager.levelNumber) {
                    case 0:
                        storyManager.StartStory(2);
                        break;
                    case 1:
                        storyManager.StartStory(4);
                        break;
                    case 2:
                        storyManager.StartStory(7);
                        break;
                }
            }
            else {

                // Checks if its a split room, if so open the right split door
                if (isSplitRoom) {
                    switch (roomManager.levelNumber) {
                        case 0:
                            StartCoroutine(MoveDoor(doorSplitLevel1, false));
                            break;
                        case 1:
                            if (roomNumber == 10) {
                                StartCoroutine(MoveDoor(doorSplitLevel2, false));
                            }
                            else {
                                StartCoroutine(MoveDoor(doorExitObject, false));
                            }
                            break;
                        case 2:
                                StartCoroutine(MoveDoor(doorExitObject, false));
                            break;
                    }
                }
                else {
                    StartCoroutine(MoveDoor(doorExitObject, false));
                }
            }
        }
    }

    // This function is for moving the door up or down, so the player can continue or he cant go back out
    IEnumerator MoveDoor(Transform door, bool goingUp) {
        Vector3 moveTo = door.position;

        if (goingUp) {
            moveTo.y += doorMoveAmount;
        }
        else {
            moveTo.y -= doorMoveAmount;
        }
        
        for (float t = 0f; t < 1; t += Time.deltaTime / doorMoveTime) {
            door.position = Vector3.Lerp(door.position, moveTo, t);
            yield return new WaitForSeconds(0);
        }
    }
}
