using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour {

    [HideInInspector]
    public float damage;

    // If the player is in this hitbox, they will take damage
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (other.tag == "Player") {
                other.GetComponent<Health>().GetDamage(damage);
            }
        }                          
    }
}
