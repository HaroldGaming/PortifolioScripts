using UnityEngine;
using System.Collections;

public class PullTowards : MonoBehaviour {
    
    public float maxPullDistance, pullSpeed;
	
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= maxPullDistance) {// pulls the player towards the object to create a dark hole effect
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, pullSpeed * Time.deltaTime);
        }
    }
}
