using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public bool allowMove;
    private float moveSpeed;
    public float[] moveChange, moveAmount;
    public float rayDistance;
    private RaycastHit hit;
	
	void Update () {
        if (allowMove) {
            MoveControls();
        }
	}

    void CheckMoveSpeed() {
        for(int i = 0; i < moveAmount.Length; i++) {
            if(moveAmount[i] <= GetComponent<PlayerSpeed>().speed) {
                moveSpeed = moveChange[i];
            }
        }
    }

    void MoveControls() {
        if (Input.GetAxis("Horizontal") > 0) {
            CheckMoveSpeed();
            if (Physics.Raycast(transform.position, transform.right, out hit, rayDistance)) { 
                if(hit.transform.tag == "StopWall") {

                }
                else {
                    transform.Translate(Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
                }
            }
            else {
                transform.Translate(Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
            }
        }

        if (Input.GetAxis("Horizontal") < 0) {
            CheckMoveSpeed();
            if (Physics.Raycast(transform.position, -transform.right, out hit, rayDistance)) {
                if (hit.transform.tag == "StopWall") {

                }
                else {
                    transform.Translate(Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
                }
            }
            else {
                transform.Translate(Vector3.left * moveSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime);
            }
        }
    }
}
