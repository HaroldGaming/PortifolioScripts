using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public bool allowMove; //is for disabling movement
    private float moveSpeed;
    public float[] moveChange, moveAmount; //is for changing the sideway movementspeed at sertain forwardspeeds
    public float rayDistance; //raycast for the side wall, so you dont fall off
    private RaycastHit hit;
	
	void Update () {
        if (allowMove) {//for if i need to disable the controllls
            MoveControls();
        }
	}

    void CheckMoveSpeed() {
        for(int i = 0; i < moveAmount.Length; i++) { //the change the sideway movement speed to the correct one.
            if(moveAmount[i] <= GetComponent<PlayerSpeed>().speed) {
                moveSpeed = moveChange[i];
            }
        }
    }

    void MoveControls() { // basic imput movement controlls. if it doesn't check the wall the player moves, else the player doesn't
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
