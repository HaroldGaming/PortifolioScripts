using UnityEngine;
using System.Collections;

public class MoveBirds : MonoBehaviour {

    private Vector2 playerPos;

	void Start () {
	
	}
	
	void Update () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(playerPos.x >= transform.position.x) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            GetComponent<SpriteRenderer>().flipX = true;
        }
	}
}
