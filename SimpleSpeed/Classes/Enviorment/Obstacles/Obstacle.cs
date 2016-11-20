using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public int number;

    void Start() {//adds the obstacle to the list
        GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleManager>().AddObstacles(gameObject);
    }
}
