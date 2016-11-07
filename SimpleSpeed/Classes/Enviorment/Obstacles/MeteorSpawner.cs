using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    public GameObject fireBall;
    public float minTimeBetweenFireBalls, maxTimeBetweenFireBalls; //minimum and maximum time between instatiates

    public IEnumerator FireBallSpawner() { //Small Routine for instatiating the fire balls between random interfalls
        Instantiate(fireBall, transform.position, transform.rotation);
        float time = Random.Range(minTimeBetweenFireBalls, maxTimeBetweenFireBalls);
        yield return new WaitForSeconds(time);
        StartCoroutine(FireBallSpawner()); 
    }
}
