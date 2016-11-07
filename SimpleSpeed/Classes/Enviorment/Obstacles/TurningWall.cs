using UnityEngine;
using System.Collections;

public class TurningWall : MonoBehaviour {

    public float rotateSpeed, minWaitTime, maxWaitTime, rotateTime; //is for rotating the wall
    private Quaternion beforeRotate, afterRotate;
    private float waitTime, time;
    private bool turned, check;

    void Update() {
        if (!check) { //does this at the start to save the rotations into variables.
            beforeRotate = transform.rotation;
            afterRotate = transform.rotation;
            afterRotate.y += 90;
            check = true;
        }

        if (waitTime >= 0) { //your basic timer
            waitTime -= Time.deltaTime;
        }
        else {
            if (turned) {// here the wall will be turned
                transform.rotation = Quaternion.Lerp(transform.rotation, beforeRotate, Time.deltaTime * rotateSpeed);
                time -= Time.deltaTime;

                if(time <= 0) {//at the end of a lerp it slows down alot, so i made a maximum timer it can spent turning
                    transform.rotation = beforeRotate;
                }

                if (transform.rotation == beforeRotate) {//wait time bewteen rotates
                    turned = false;
                    waitTime = Random.Range(minWaitTime, maxWaitTime);
                }
            }
            else {//sets it to the original turn position so it can turn again
                transform.rotation = afterRotate;
                turned = true;
                time = rotateTime;
            }
        }
    }
}
