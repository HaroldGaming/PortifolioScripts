using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public float score, addScore, increaseAddScore, maxAddScore;// your score, how much score is being added and this score is being scaled too. uptill a max amount
    //private float highScore;
    private PlayerSpeed speed;
    private Health health;
   

	void Start () {// saving the classes in vars, so i dont have to keep calling them.
        speed = GetComponent<PlayerSpeed>();
        health = GetComponent<Health>();
	}
	
	void Update () {//formula for multiplieing the score when you go faster and the lower shield you have.
        float tempSpeedMultiplier = 1+ (1 / speed.maxSpeed * speed.speed);
        float tempHealthMultiplier = 1+ (1 - (1 / health.maxShield * health.currentShield));
        score += addScore * tempSpeedMultiplier * tempHealthMultiplier * Time.deltaTime;

       // if(score >= highScore) {//is for the future highscore
           // highScore = score;
       // }

        if(addScore <= maxAddScore) {//is for the scaling score each second, this does have a max
            addScore += increaseAddScore * Time.deltaTime;
        }
        else {
            addScore = maxAddScore;
        }       
	}
}
