using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    [Header("Stats")] // With these variables you can change how long the enemy will take for its attack, how big the chance for a drop is, the time it takes to spawn and how often it needs to check if it needs to attack or walk
    [SerializeField]
    private float spawningSpeed; // Maximum spawn speed
    [SerializeField]
    private float spawnTime; // Maximum spawn time

    [Header("Setteble Variables")] // These variables need to be filled in the unity editor
    [SerializeField]
    private AudioClip enemyDeath; // Sound clip of the enemy dying
    [SerializeField]
    protected Animator animations; // Enemy animator
    [Header("Rest")] // These variables will be changed and checked only within the classes
    private bool isStunned;
    [HideInInspector]
    public RoomTrigger roomTrigger;
    private AudioSource enemySoundObj;

    // Making the enemies spawn from the ground and drop them. after that activating the walking
    public IEnumerator Spawn() {

        // Set enemy to being invulnerenable
        GetComponent<Health>().invulnerable = true;

        // Move the enemy upwards from under the ground
        transform.GetComponent<Rigidbody>().velocity += transform.up * spawningSpeed;
        yield return new WaitForSeconds(spawnTime);

        // Sets the gravity on again and sets the enemy to being physical again
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().isTrigger = false;
        yield return new WaitForSeconds(spawnTime);

        // Starts the movement
        StartMoving();

        // Turn off invulnerability
        GetComponent<Health>().invulnerable = false;
    }

    // Stops the walk/attack coroutine as a form of stun. it will call upon a coroutine to wait for the unstun.
    public void Stunned(float stunTime) {

        // Checks if the enemy is stunnable
        if (IsStunnable()) {
            print(isStunned);
            isStunned = true;
            StopAllCoroutines();
            StartCoroutine(UnStunned(stunTime));
        }
    }

    // After the stun time is over the enemy will be able to walk/attack again
    private IEnumerator UnStunned(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
        StartMoving();
    }

    // Making the enemy drop an "item" if roll was good and then destroy themselves
    public void Die() {
        StopAllCoroutines();

        // Sets and plays the death animation/sound
        enemySoundObj = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<AudioSource>();
        enemySoundObj.clip = enemyDeath;
        animations.SetTrigger("Dead");
        enemySoundObj.Play();

        // Start the loot dropping
        DropLoot();
        roomTrigger.EnemyCheck();
        Destroy(gameObject);
    }


    // Sets a random cooldown between attacks, this is so that the enemies are not all the same
    protected virtual void Start() {
        isStunned = false;
    }

    // Starts the enemy movement
    protected virtual void StartMoving() {
    }

    // Whether enemy is currently stunned
    protected virtual bool IsStunnable() {
        return !isStunned;
    }

    // Enemy drops the loots
    protected virtual void DropLoot() {
    }
}