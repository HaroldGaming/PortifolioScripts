using UnityEngine;
using System.Collections;

public class MoveMent : MonoBehaviour {

    private float timer;
    public float rayDistance, moveNotAllowedTime, force, maxForce, moveSpeed, deadZone, increaseForce, procentForceIncreaseTime, procentForceIncreaseHit;
    private bool allowMove;
    public int timesHit, increaseForcePerHit;

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

        if(gameObject.transform.position.y < deadZone) {
            Dead();
        }
        
        if(force <= maxForce) {
            force += increaseForce * (force / procentForceIncreaseTime) * Time.deltaTime;
        }
    }

    void Dead() {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndLevel();
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

    void IncreaseForce() {
        if(force <= maxForce) {
            force += (increaseForcePerHit * (timesHit / procentForceIncreaseHit));
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.transform.tag == "Enemy") {
            timer = moveNotAllowedTime;
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
            IncreaseForce();
            timesHit++;
        }
    }
}
