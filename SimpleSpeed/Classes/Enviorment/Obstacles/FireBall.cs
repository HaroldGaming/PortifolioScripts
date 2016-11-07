using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public float minSpeed, maxSpeed, destroyTime;//min and max speed of the object, destroy itself after a sertain time.
    private float speed;
    public int damage;

    void Start() {//speed is randomized
        speed = Random.Range(minSpeed, maxSpeed);
    }

	void Update () {// forward movement and destroy itself after a sertain time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(destroyTime >= 0) {
            destroyTime -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider trigger) {//damages the player and destroy itself if it hits the player
        if(trigger.tag == "Player") {
            trigger.GetComponent<ObstacleManager>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
