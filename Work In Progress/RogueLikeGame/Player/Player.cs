using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public int level = 3;
    public int health = 40;
    private GameManager gameManager;

    private void Start() {//adds the game manager to the player to be called upon
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {//player hits the exit door to go to the next level
        if (other.tag == "exitdoor") {
           gameManager.LoadNextLevel();
        }
    }
}
