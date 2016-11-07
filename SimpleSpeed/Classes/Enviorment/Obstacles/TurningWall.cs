using UnityEngine;
using System.Collections;

public class TurningWall : MonoBehaviour {

    public float rotateSpeed, minWaitTime, maxWaitTime, rotateTime;
    private Quaternion beforeRotate, afterRotate;
    private float waitTime, time;
    private bool turned, check;

    void Update() {
        if (!check) {
            beforeRotate = transform.rotation;
            afterRotate = transform.rotation;
            afterRotate.y += 90;
            check = true;
        }

        if (waitTime >= 0) {
            waitTime -= Time.deltaTime;
        }
        else {
            if (turned) {
                transform.rotation = Quaternion.Lerp(transform.rotation, beforeRotate, Time.deltaTime * rotateSpeed);
                time -= Time.deltaTime;

                if(time <= 0) {
                    transform.rotation = beforeRotate;
                }

                if (transform.rotation == beforeRotate) {
                    turned = false;
                    waitTime = Random.Range(minWaitTime, maxWaitTime);
                }
            }
            else {
                transform.rotation = afterRotate;
                turned = true;
                time = rotateTime;
            }
        }
    }
}
