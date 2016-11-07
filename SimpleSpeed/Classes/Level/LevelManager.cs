using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject spawnPlatform, Player;
    public Quaternion playerRotation;
    public GameObject[] planes;
    public bool first;

	void Start () {//sets vars so i dont have to keep calling them.
        first = true;
        spawnPlatform = GameObject.FindGameObjectWithTag("SpawnPlatform");
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRotation = Player.transform.rotation;
	}

    public void CheckPointGet() {//is for the checkpoint check, floor goes away after the first checkpoint regardless.
        if (first) {
            for(int i = 0; i <= planes.Length-1; i++) {
                planes[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }//sets the player back to the start of the check and checks if the envirement or obstacles need to be changed
        Player.transform.position = spawnPlatform.transform.position;
        Player.transform.rotation = playerRotation;
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ChangeManagement>().CheckChange();
        Player.GetComponent<ObstacleManager>().ObstacleRandommizer();
        first = false;

    }
}

