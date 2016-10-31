using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectSystem : MonoBehaviour {

    private bool holding;
    public int score;
    public float incraseMoveSpeedPerPoint;
    public GameObject collectPoint, pickUp;

    public List<GameObject> collectPoints = new List<GameObject>();

	void Start () {
        SetActivePoint();
	}

    void SetActivePoint() {
        int randomNum = Random.Range(0, collectPoints.Count-1);
        collectPoints[randomNum].GetComponent<CollectPoint>().Chosen();
    }

    void OnTriggerEnter(Collider trigger) {

        if (trigger.GetComponent<CollectPoint>() != null) {
            if (trigger.GetComponent<CollectPoint>().chosen == true) {
                holding = true;
                pickUp.SetActive(true);
                trigger.GetComponent<CollectPoint>().Picked();
            }
        }

        if (holding) {
            if(trigger.gameObject == collectPoint) {
                score++;
                GetComponent<MoveMent>().moveSpeed += incraseMoveSpeedPerPoint;
                holding = false;
                pickUp.SetActive(false);
                SetActivePoint();
            }
        }
    }

    public void Lose() {
        holding = false;
        pickUp.SetActive(false);
        SetActivePoint();
    }
}
