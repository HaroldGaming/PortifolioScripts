using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionBehavior : MonoBehaviour {

    public float moveSpeed;
    public float[] increasePerSecond;
    public GameObject spawner;
    public float agroRange;
    private GameObject player;
    private MinionSpawner spawnScript;
    [SerializeField]
    private Transform curretTarget;
    private int counter;
    public int teamNumber; 

    [SerializeField]
    private List<Transform> wayPointList = new List<Transform>();

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnScript = spawner.GetComponent<MinionSpawner>();
        AddWayPoints();
        curretTarget = wayPointList[counter];
    }

    void Update() {
        transform.LookAt(curretTarget.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (teamNumber == 1) {
            float tempSpeed = player.GetComponent<MoveMent>().moveSpeed - 2;
            if (tempSpeed >= moveSpeed) {
                moveSpeed += increasePerSecond[1] * Time.deltaTime;
            }
        }
        else {
            float tempSpeed2 = player.GetComponent<MoveMent>().moveSpeed * 2;
            if(tempSpeed2 >= moveSpeed) {
                moveSpeed += increasePerSecond[0] * Time.deltaTime; 
            }
        }

        if(teamNumber == 1) {
            SearchPlayer();
        }
    }

    void SearchPlayer() {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist <= agroRange) {
            curretTarget = player.transform;
        }
        else {
            curretTarget = wayPointList[counter];
        }

    }

	void AddWayPoints(){
		for(int i = 0; i < spawnScript.waypointList.Length; i++){
			wayPointList.Add(spawnScript.waypointList[i]);
		}
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.transform == wayPointList[counter]){
			counter++;
			if(counter >= wayPointList.Count){
				counter = 0;
			}
			curretTarget = wayPointList[counter];
           
        }
	}
}
