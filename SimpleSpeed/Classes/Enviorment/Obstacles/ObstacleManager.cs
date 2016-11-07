using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {

    private PlayerSpeed speed;
    private Health playerHealth;
    public float reduceSpeedOnHitProcent, reduceSpeedIncreaseOnHitProcent, scoreAddLostAmountProcent;

    private List<GameObject> obstacleList = new List<GameObject>();
    private List<GameObject> obstacleOffList = new List<GameObject>();

    void Start() {
        speed = GetComponent<PlayerSpeed>();
        playerHealth = GetComponent<Health>();
    }

    public void AddObstacles(GameObject obstacle) {
        if(obstacle.GetComponent<Obstacle>().number == 0) {
            obstacleList.Add(obstacle);
        }
        else {
            obstacleOffList.Add(obstacle);
            obstacle.SetActive(false);
        }
        
    }

    public void ObstacleRandommizer() {
        for(int i = 0; i <= obstacleList.Count-1; i++) {
            int randomNum = Random.Range(0, 2);
            if(randomNum == 1){
                obstacleList[i].SetActive(true);
                if(obstacleList[i].GetComponent<Obstacle>().number == 1) {
                    obstacleList[i].GetComponent<MeteorSpawner>().StartCoroutine(obstacleList[i].GetComponent<MeteorSpawner>().FireBallSpawner());
                }
            }
            else {
                obstacleList[i].SetActive(false);
            }
        }
    }

    public void ChangeObstacles(int counter) {
        if (counter == 0) {
            for (int i = 0; i <= obstacleList.Count - 1; i++) {
                obstacleList[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else {
            for (int i = 0; i <= obstacleOffList.Count - 1; i++) {
                if(obstacleOffList[i].GetComponent<Obstacle>().number == counter) {
                    obstacleList.Add(obstacleOffList[i]);
                }
            }
        }
    }

    void OnTriggerEnter(Collider trigger) {
        if (trigger.tag == "Obstacle") {
            Hit(trigger.GetComponent<Obstacle>().damage);
        }
    }

    public void Hit(int damage) {
        OnHitEffect();
        speed.speed = (speed.speed / 100 * (100 - reduceSpeedOnHitProcent));
        speed.speedIncrease = (speed.speedIncrease / 100 * (100 - reduceSpeedIncreaseOnHitProcent));
        Score score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        score.addScore = score.addScore / 100 * (100 - scoreAddLostAmountProcent);
        playerHealth.GetDamage(damage);
    }

    void OnHitEffect() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camara>().ObstacleHit();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
