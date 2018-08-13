using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : EnemyControl {

    [Header("Stats")] // With these variables you can change how long the enemy will take for its attack, how big the chance for a drop is, the time it takes to spawn and how often it needs to check if it needs to check if it needs to attack or walk
    [SerializeField]
    private float moveSpeed; // Maximum movent speed per second
    [SerializeField]
    private float turnSpeed; // Maximum turn speed per second
    [SerializeField]
    private float minAttackCooldown; // Minum cooldown between each attack
    [SerializeField]
    private float maxAttackCoolDown; // Maximum cooldown between each attack
    [SerializeField]
    private float attackRange; // Maximum attack range
    [SerializeField]
    private float attackDamage; // Maximum attack damage
    [SerializeField]
    private float walkTime; // Maximum time between checking if the enemy needs to walk or attack.
    [SerializeField]
    private int lootDropChance; // Maximum loot drop chance in % from 0 - 100
    [SerializeField]
    private int crystalDropChance; // Maximum crystal drop chance in % from 0 - 100
    public float timeBeforeHit; // Maximum time before the enemy attacks
    public float timeAfterHit; // Maximum time before the enemy has recoverd

    [Header("Setteble Variables")] // These variables need to be filled in the unity editor
    [SerializeField]
    private ParticleSystem attackEffect; // Particle system for attack effects
    [SerializeField]
    private AudioClip attackSound; // Sound clip for attack sound
    [SerializeField]
    private GameObject powerCrystal; // Prefap for the power crystal
    [SerializeField]
    private GameObject healthPickUp; // prefap for the health pick up
    [SerializeField]
    private GameObject attackHitBox; //attack hitbox of the enemy
    [SerializeField]
    private Transform pivitPoint; // Point from where to check the attack from.

    [Header("Rest")] // These variables will be changed and checked only within the classes
    [HideInInspector]
    public bool allowAttack;
    [HideInInspector]
    public bool allowMove;
    [HideInInspector]
    public GameObject playerTarget;
    private float attackCooldown;

    protected override void Start() {
        base.Start();
        attackCooldown = Random.Range(minAttackCooldown, maxAttackCoolDown);
        allowAttack = true;
    }

    protected override void StartMoving() {
        base.StartMoving();

        // Start walking methode
        StartCoroutine(Walk());
        animations.SetBool("Walk", true);
    }

    protected override void DropLoot() {
        base.DropLoot();

        // Calculates the loot drop chance and what to drop. Then it instantiates an item if the roll is a success
        int lootroll = Random.Range(0, 100);

        if (lootroll <= lootDropChance) {
            int crystalRoll = Random.Range(0, 100);

            if (crystalRoll <= crystalDropChance) {
                Instantiate(powerCrystal, transform.position, transform.rotation);
            }
            else {
                Instantiate(healthPickUp, transform.position, transform.rotation);
            }
        }
    }

    // Makes the enemy turn towards the player and move forward
    void Update() {
        if (allowMove) {
            MoveForward();
            TurnToPlayer();
        }
    }

    // Makes the enemy walk towards the player until they are in attack range
    private IEnumerator Walk() {

        // Start walking
        allowMove = true;
        yield return new WaitForSeconds(walkTime);

        // Check if the player is in range for attack
        float dist = Vector3.Distance(playerTarget.transform.position, transform.position);

        if (dist <= attackRange) {

            // Start attack method
            StartCoroutine(StopToAttack());
            StopCoroutine(Walk());
        }
        else {

            // Continue walk method
            StartCoroutine(Walk());
        }
    }

    // Makes the enemy stop if they are in range of the player
    private IEnumerator StopToAttack() {

        // Stop moving
        allowMove = false;
        animations.SetBool("Walk", false);

        // Perform attack
        if (allowAttack) {
            TurnToPlayer();
            yield return new WaitForSeconds(timeBeforeHit);
            animations.SetTrigger("Attack");
            attackHitBox.GetComponent<AttackHitBox>().damage = attackDamage;
            attackHitBox.SetActive(true);
            yield return new WaitForSeconds(timeAfterHit);
            attackHitBox.SetActive(false);
        }
        yield return new WaitForSeconds(attackCooldown);

        // Find whether player is in reach
        float dist = Vector3.Distance(playerTarget.transform.position, transform.position);

        if (dist >= attackRange) {

            // If out of reach, start moving towards the player
            StartCoroutine(Walk());
            animations.SetBool("Walk", true);
            StopCoroutine(StopToAttack());
        }
        else {

            // Continue attacking if in reach
            StartCoroutine(StopToAttack());
        }
    }

    // Makes the enemy move forward
    private void MoveForward() {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    // Makes the enemy turn towards the player
    private void TurnToPlayer() {
        var lookPos = playerTarget.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
    }
}
