using UnityEngine;
using System.Collections;

public class ObstacleDamage : MonoBehaviour {

    private float leftPosition, rightPosition, frontPosition, backPosition, topPosition, botPosition;
    public float devideValue; // is for tweaking the "hitbox".
    public int damage;
    private float timer;

	
	void Update () {
        if (timer <= 0) {//this is for that the player won't be hit 999 times in a row
            SetPosition();
            CheckForDamage();
        }
        else {
            timer -= Time.deltaTime;
        }
	}

    void CheckForDamage() {//checking if the position of the player is in range for the obstacle to hit the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;

        if(playerPosition.x >= leftPosition && playerPosition.x <= rightPosition && playerPosition.z >= frontPosition && playerPosition.z <= backPosition && playerPosition.y >= botPosition && playerPosition.y <= topPosition){
            print(name);
            player.GetComponent<ObstacleManager>().Hit(damage);
            timer = 5;
        }
    }

    void SetPosition() { //setting place of the obstacle, so it can check when it hits the player.
        leftPosition = transform.position.x;
        leftPosition -= (transform.localScale.x / devideValue);

        rightPosition = transform.position.x;
        rightPosition += (transform.localScale.x / devideValue );

        frontPosition = transform.position.z;
        frontPosition -= (transform.localScale.z / devideValue);

        backPosition = transform.position.z;
        backPosition += (transform.localScale.z / devideValue);

        topPosition = transform.position.y;
        topPosition += transform.localScale.y;

        botPosition = transform.position.y;
        botPosition -= transform.localScale.y;
    }
}
