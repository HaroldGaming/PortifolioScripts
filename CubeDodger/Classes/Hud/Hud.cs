using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    private string time, force, wave, hit;
    public GameObject timer, forces, waves, hits;
    private GameManager gameManager;
    private MoveMent player;
    private SpawnManager spawnManager;

    public GameObject[] activateList;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveMent>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update() {

        time = string.Format("{0}", (int)gameManager.gameTimer);
        force = string.Format("{0}", (int)player.force);
        wave = string.Format("{0}", spawnManager.waveCount);
        hit = string.Format("{0}", player.timesHit);

        timer.GetComponent<Text>().text = time;
        forces.GetComponent<Text>().text = force;
        waves.GetComponent<Text>().text = wave;
        hits.GetComponent<Text>().text = hit;
    }

    public void Activator(GameObject hudObject) {
        hudObject.SetActive(true);
    }

    public void DeActivator(GameObject hudObject) {
        hudObject.SetActive(false);
    }
}
