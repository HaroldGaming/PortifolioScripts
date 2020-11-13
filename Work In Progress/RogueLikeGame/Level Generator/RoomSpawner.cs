using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour{
    public string openingDirection;
    // bottom needs bottom door
    // top needs top door
    // left needs left door
    // right needs right door
    public GameObject roomParent;

    [SerializeField]
    //private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;

    private void Start() {
        Destroy(gameObject, waitTime);
        RoomTemplates templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        roomParent = GameObject.FindGameObjectWithTag("roomlist");
        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        RoomTemplates templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        if (spawned == false) {
            GameObject temp = null;
            switch (openingDirection) {               
                case "bottom":
                    // Need to spawn a room with a BOTTOM door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                   temp = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;
                case "top":
                    // Need to spawn a room with a TOP door
                    rand = Random.Range(0, templates.topRooms.Length);
                    temp = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case "left":
                    // Need to spawn a room with a LEFT door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    temp = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation); ;
                    break;
                case "right":
                    // Need to spawn a room with a Right door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    temp = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
            }
            if (temp != null) {
                temp.transform.parent = roomParent.transform;
            }
            spawned = true;           
        }
    }

    private void OnTriggerEnter(Collider other) {
        RoomTemplates templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        if (other.CompareTag("spawnpoint")) {
            RoomSpawner roomSpawner = other.GetComponent<RoomSpawner>();
            if (roomSpawner?.spawned == false && spawned == false) { 
                // spawn walls blocking off any openings              
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);                               
                Destroy(gameObject);                
            }           
            spawned = true;           
        }
    }
}
