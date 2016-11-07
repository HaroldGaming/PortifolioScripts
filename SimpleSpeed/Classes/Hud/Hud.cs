using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    private string score, highScore;
    public GameObject scores, highScores;
    private Score scoreClass;

    void Start() {
        scoreClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }

    void Update() {
        score = string.Format("{0}", (int)scoreClass.score);
        //highScore = string.Format("{0}", (int)scoreClass.score);

        scores.GetComponent<Text>().text = score;
        //highScores.GetComponent<Text>().text = highScore;
    }

    public void Activator(GameObject hudObject) {
        hudObject.SetActive(true);
    }

    public void DeActivator(GameObject hudObject) {
        hudObject.SetActive(false);
    }
}
