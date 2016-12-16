using UnityEngine;
using System.Collections;

public class DeathHit : MonoBehaviour {

    private PlayerHealth health;
    private Vector2 spawnPosition;

    void Start() {
        spawnPosition = transform.position;
        health = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Death") {
            health.GetDamage();
            transform.position = spawnPosition;
        }
    }
}
