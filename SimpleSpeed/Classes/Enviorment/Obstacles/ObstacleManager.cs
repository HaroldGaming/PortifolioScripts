using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {

    private PlayerSpeed speed;
    private Health playerHealth;
    public float reduceSpeedOnHitProcent, reduceSpeedIncreaseOnHitProcent, scoreAddLostAmountProcent;//the procent amount you lose after you get hit

    private List<GameObject> obstacleList = new List<GameObject>();
    private List<GameObject> obstacleOffList = new List<GameObject>();

    void Start() {// putting classes into vars so i dont have to keep calling them
        speed = GetComponent<PlayerSpeed>();
        playerHealth = GetComponent<Health>();
    }

    public void AddObstacles(GameObject obstacle) {//obstacles add them selves into the off list. only the first obstacles will be added to the active list.
        if(obstacle.GetComponent<Obstacle>().number == 0) {
            obstacleList.Add(obstacle);
        }
        else {
            obstacleOffList.Add(obstacle);
            obstacle.SetActive(false);
        }
        
    }

    public void ObstacleRandommizer() {//Randomizer so see if a obstacle will remain off or on.
        for(int i = 0; i <= obstacleList.Count-1; i++) {
            int randomNum = Random.Range(0, 2);
            if(randomNum == 1){
                obstacleList[i].SetActive(true);
                if(obstacleList[i].GetComponent<Obstacle>().number == 1) {// added this for my routine obstacles. i had problems with the awake/start, so i added this instead
                    obstacleList[i].GetComponent<MeteorSpawner>().StartCoroutine(obstacleList[i].GetComponent<MeteorSpawner>().FireBallSpawner());
                }
            }
            else {
                obstacleList[i].SetActive(false);
            }
        }
    }

    public void ChangeObstacles(int counter) {//checks wich obstacles need to be activated
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

    void OnTriggerEnter(Collider trigger) {//checks if the player hits a obstacle
        if (trigger.tag == "Obstacle") {
            Hit(trigger.GetComponent<Obstacle>().damage);
        }
    }

    public void Hit(int damage) {// Calls on hit effect and does a calculation on how to substract from sertain stats.
        OnHitEffect();
        speed.speed = (speed.speed / 100 * (100 - reduceSpeedOnHitProcent));
        speed.speedIncrease = (speed.speedIncrease / 100 * (100 - reduceSpeedIncreaseOnHitProcent));
        Score score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        score.addScore = score.addScore / 100 * (100 - scoreAddLostAmountProcent);
        playerHealth.GetDamage(damage);
    }

    void OnHitEffect() {//screen shake and audio hit effect.
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camara>().ObstacleHit();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
