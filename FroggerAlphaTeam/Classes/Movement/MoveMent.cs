using UnityEngine;
using System.Collections;

public class MoveMent : MonoBehaviour {

    private float timer;
    public float rayDistance, moveNotAllowedTime, moveSpeed;
    private bool allowMove;

    void Start() {
        allowMove = true;
    }

    void Update() {
        if (allowMove) {
            MovementControlls();
        }
        
        if(timer >= 0) {
            allowMove = false;
            timer -= Time.deltaTime;
        }
        else {
            allowMove = true;
        }
    }

    public void NoMove() {
        timer = moveNotAllowedTime;
    }

    void MovementControlls() {
        if (Input.GetAxis("Vertical") > 0) {
            if (Physics.Raycast(transform.position, transform.forward, rayDistance)) {
            }
            else {
                transform.Translate(Vector3.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
            }
        }

        if (Input.GetAxis("Vertical") < 0) {
            if (Physics.Raycast(transform.position, -transform.forward, rayDistance)) {
            }
            else {
                transform.Translate(Vector3.back * moveSpeed * -Input.GetAxis("Vertical") * Time.deltaTime);
            }
        }

        if (Input.GetAxis("Horizontal") > 0) {
            if (Physics.Raycast(transform.position, transform.right, rayDistance)) {
            }
            else {
                transform.Translate(Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
            }
        }

        if (Input.GetAxis("Horizontal") < 0) {
            if (Physics.Raycast(transform.position, -transform.right, rayDistance)) {
            }
            else {
                transform.Translate(Vector3.left * moveSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime);
            }
        }
    }
}
