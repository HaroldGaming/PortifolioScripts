using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public int currentHealth, startHealth, damage, teamNumber;
    private int maxHealth;

    public bool insideTurret;
    public bool attackedByPlayer;
    public bool dead;
    public GameObject playerAttackedBy;
    public GameObject turretIAmIn;
    
    void Start () {
        maxHealth = startHealth;
        currentHealth = startHealth;
    }

    public void HealthReset(){
        currentHealth = maxHealth;
    }

    public void GetDamage(int damage) {
        //damage calculation
        currentHealth -= damage;
    }
}
