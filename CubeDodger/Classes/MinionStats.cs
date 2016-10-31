using UnityEngine;
using System.Collections;

public class MinionStats : MonoBehaviour {

    public float timer;
    public SpawnManager spawnManager;

	void Start () {
        spawnManager.CheckCurrentWave();
    }
	
	void Update () {
	    if(timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
	}


    public void IncreaseStats(int incraseAmount) {
        print(incraseAmount);
    }
}
