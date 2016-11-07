using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

    private float timer;

	void Awake () {
        timer = 5;
	}
	
	void Update () {
	    if(timer <= 0) {
            gameObject.SetActive(false);
        }
        else {
            timer -= Time.deltaTime;
        }
	}
}
