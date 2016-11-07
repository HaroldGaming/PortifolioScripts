using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject spawnPlatform, Player;
    public Quaternion playerRotation;
    public GameObject[] planes;
    public bool first;

	void Start () {
        first = true;
        spawnPlatform = GameObject.FindGameObjectWithTag("SpawnPlatform");
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRotation = Player.transform.rotation;
	}

    public void CheckPointGet() {
        if (first) {
            for(int i = 0; i <= planes.Length-1; i++) {
                planes[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        Player.transform.position = spawnPlatform.transform.position;
        Player.transform.rotation = playerRotation;
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ChangeManagement>().CheckChange();
        Player.GetComponent<ObstacleManager>().ObstacleRandommizer();
        first = false;

    }
}

