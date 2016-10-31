using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    private string score, life, moveSpeed;
    public GameObject scores, lifes, moveSpeeds;
    private Stats stats;
    private MoveMent player;
    private CollectSystem collect;


    public GameObject[] activateList;

    void Start() {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveMent>();
        collect = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectSystem>();
    }

    void Update() {

        moveSpeed = string.Format("{0}", player.moveSpeed);
        score = string.Format("{0}", collect.score);
        life = string.Format("{0}", stats.life);

        scores.GetComponent<Text>().text = score;
        lifes.GetComponent<Text>().text = life;
        moveSpeeds.GetComponent<Text>().text = moveSpeed;
    }

    public void Activator(GameObject hudObject) {
        hudObject.SetActive(true);
    }

    public void DeActivator(GameObject hudObject) {
        hudObject.SetActive(false);
    }
}
