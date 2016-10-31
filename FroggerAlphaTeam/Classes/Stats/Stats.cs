using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    private float time;
    public float invisibilityTime, deadZone;
    public int life;
    private Vector3 spawnPosition;

	void Start () {
        spawnPosition = transform.position;
	}
	
	void Update () {
	    if(time >= 0) {
            time -= Time.deltaTime;
        }

        if (gameObject.transform.position.y < deadZone) {
            LoseLife();
        }
    }

    public void LoseLife() {
        if (time <= 0) {
            life--;
            GetComponent<CollectSystem>().Lose();
            CheckDeath();
            time = invisibilityTime;
            transform.position = spawnPosition;
            GetComponent<MoveMent>().NoMove();
        }
    }

    void CheckDeath() {
        if(life == 0) {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.transform.tag == "Enemy") { 
            LoseLife();
        }
    }
}
