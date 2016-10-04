using UnityEngine;
using System.Collections;

public class MoveMent : MonoBehaviour {

    public float moveSpeed;
    public float rayDistance;
    public bool allowMove;

    void Start() {
        allowMove = true;
    }

    void Update() {
        if (allowMove) {
            MovementControlls();
        }
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