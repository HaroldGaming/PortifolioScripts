using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private int score;

    public void AddScore(int amount) {
        score += amount;
        SetHudScore();
    }

    void SetHudScore() {
        GameObject.FindGameObjectWithTag("HudManager").GetComponent<HudPoints>().Points(score);
    }
}
