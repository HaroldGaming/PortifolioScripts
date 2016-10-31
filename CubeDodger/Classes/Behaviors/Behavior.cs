using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour {

    private float time;
    private bool done;
    public float moveSpeed;
    private Transform target;

	void Start () {
        done = false;
        int randomNum = Random.Range(0, 360);
        transform.rotation = Quaternion.AngleAxis(randomNum, Vector3.up);
        time = GetComponent<MinionStats>().timer / 2;
    }
	
	void Update () {
        Move();

        if (!done) {
            if (time <= 0) {
                ChangeMovent(moveSpeed);
            }
            else {
                time -= Time.deltaTime;
            }
        }
    }

    void ChangeMovent(float speed) {
        moveSpeed = -speed;
        done = true;
    }

    void Move() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
        if(col.transform.tag == "Enemy") {
            ChangeMovent(moveSpeed);
        }
    }
}
