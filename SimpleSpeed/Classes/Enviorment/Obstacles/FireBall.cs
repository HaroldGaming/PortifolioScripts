using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public float minSpeed, maxSpeed, destroyTime;
    private float speed;
    public int damage;

    void Start() {
        speed = Random.Range(minSpeed, maxSpeed);
    }

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(destroyTime >= 0) {
            destroyTime -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider trigger) {
        if(trigger.tag == "Player") {
            trigger.GetComponent<ObstacleManager>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
