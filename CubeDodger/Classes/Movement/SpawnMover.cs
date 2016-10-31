using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMover : MonoBehaviour {

    private int counter;
    public float moveSpeed;
    private Transform currentTarget;

    public List<Transform> activeWayPointList = new List<Transform>();

    void Start() {
        currentTarget = activeWayPointList[0];
    }

    void Update() {
        transform.LookAt(currentTarget.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider trigger) {
        if (trigger.transform == activeWayPointList[counter]) {
            counter++;
            if (counter >=activeWayPointList.Count) {
                counter = 0;
            }
            currentTarget = activeWayPointList[counter];
        }
    }
}
