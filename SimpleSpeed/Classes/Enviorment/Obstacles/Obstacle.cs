using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public int number, damage;

    void Start() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleManager>().AddObstacles(gameObject);
    }
}
