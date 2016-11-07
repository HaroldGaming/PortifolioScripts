using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public float score, addScore, increaseAddScore, maxAddScore;
    //private float highScore;
    private PlayerSpeed speed;
    private Health health;
   

	void Start () {
        speed = GetComponent<PlayerSpeed>();
        health = GetComponent<Health>();
	}
	
	void Update () {
        float tempSpeedMultiplier = 1+ (1 / speed.maxSpeed * speed.speed);
        float tempHealthMultiplier = 1+ (1 - (1 / health.maxShield * health.currentShield));
        score += addScore * tempSpeedMultiplier * tempHealthMultiplier * Time.deltaTime;

       // if(score >= highScore) {
           // highScore = score;
       // }

        if(addScore <= maxAddScore) {
            addScore += increaseAddScore * Time.deltaTime;
        }
        else {
            addScore = maxAddScore;
        }       
	}
}
