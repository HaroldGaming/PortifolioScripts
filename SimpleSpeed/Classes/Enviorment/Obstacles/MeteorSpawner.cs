using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    public GameObject fireBall;
    public float minTimeBetweenFireBalls, maxTimeBetweenFireBalls;

    public IEnumerator FireBallSpawner() {
        Instantiate(fireBall, transform.position, transform.rotation);
        float time = Random.Range(minTimeBetweenFireBalls, maxTimeBetweenFireBalls);
        yield return new WaitForSeconds(time);
        StartCoroutine(FireBallSpawner()); 
    }
}
