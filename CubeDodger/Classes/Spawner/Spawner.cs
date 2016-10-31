using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public SpawnManager spawnManager;
    public int counter;

    public List<int> spawnAmount = new List<int>();

    public IEnumerator Spawning(float timer) { //spawns the enemies
        yield return new WaitForSeconds(timer);
        if(spawnAmount[0] > 0) {
            GameObject temp = Instantiate(spawnManager.minionArray[counter], transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation) as GameObject;
           
            temp.GetComponent<MinionStats>().spawnManager = spawnManager;
            spawnAmount[0]--;
            StopCoroutine("Spawning");
            StartCoroutine(Spawning(timer));
        }
        else {
            if (0 != spawnAmount.Count-1) {
                spawnAmount.Remove(spawnAmount[0]);
                counter++;
                StopCoroutine("Spawning");
                StartCoroutine(Spawning(timer));
            }
            else {
                spawnAmount.Remove(spawnAmount[0]);
                StopCoroutine("Spawning");
            }
        }
    }
}
