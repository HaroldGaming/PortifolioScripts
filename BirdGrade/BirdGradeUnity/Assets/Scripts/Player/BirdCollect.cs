using UnityEngine;
using System.Collections;

public class BirdCollect : MonoBehaviour {

    private Score scoreClass;
    private CollectPerArea areaClass;
    public AudioClip collect;
    private SoundManager soundManager;

    void Start() {
        scoreClass = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
        areaClass = GameObject.FindGameObjectWithTag("Level").GetComponent<CollectPerArea>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }


    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Bird") {
            soundManager.PlaySound(collect, 0.3F);
            scoreClass.AddScore(col.gameObject.GetComponent<BirdPoints>().pointsAmount);
            areaClass.AddBirdCount();
            col.gameObject.SetActive(false);
        }
    }
}