using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public int type;
    
    [SerializeField]
    private AudioClip pickUpSound; // Pick up sound of the power crystal
    [SerializeField]
    private float healAmount; // Amount that needs to be healed
    [SerializeField]
    private GameObject crystalPickup, healthPickup; // Prefaps for the health and power crystal
    private AudioSource soundObj;

    // If the player walks into the item depending on the type it will either give 1 crystal or heals the player
    private void OnTriggerEnter(Collider other) {

        // Checks if the object that goes trough pick up is the player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {        
              
            if (other.tag == "Player") {
                switch (type) {
                    case 0:

                        // Sets the audiosource the sound needs to play from, then plays the sound
                        soundObj = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<AudioSource>();
                        soundObj.clip = pickUpSound;
                        soundObj.Play();

                        // Instantiates the crystal pickup
                        Instantiate(crystalPickup, transform.position, transform.rotation);
                        other.GetComponent<CrystalEffect>().CheckBuff(other.gameObject);
                        break;
                    case 1:

                        // Instantiates the health pickup
                        other.GetComponent<Health>().Heal(healAmount);
                        Instantiate(healthPickup, transform.position, transform.rotation);
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}

