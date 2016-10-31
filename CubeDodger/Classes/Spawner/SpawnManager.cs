using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public int increaseProcentPerWave, startingWave; //with how much % do you want to incease the stats and the amonut of enemies that need to be spawned, the armount enemies currently spawned, the wave you start at
    public float timeBetweenWaves, timeBetweenMinions; // time between each wave after a wave is finished. spawn time between the minions
    private int maxSpawnAmount, currentSpawnAmount;
    public int waveCount;

    public List<GameObject> spawnPointArray = new List<GameObject>(); // Place all the spawnpoint of the level here. Place wich minions need to be spawned
    public List<string> spawnPointTagArray = new List<string>(); // All the tags of the spawnpoint. is needed to see wich spawnpoints need to be activated.
    public List<int> spawnAmount = new List<int>(); // how many of each enemy needs to be spawned
    public List<GameObject> minionArray = new List<GameObject>();
    public List<GameObject> activeSpawnList = new List<GameObject>();
    private List<GameObject> offSpawnList = new List<GameObject>();
    private List<int> saveSpawnAmount = new List<int>();
    private List<int> amountForEachSpawner = new List<int>();

    void Awake() {
        waveCount = startingWave;
        SetAmountLength();
        SaveSpawnAmount();
        AddOffList(); // adds the waypoints to a non active list
        CheckForActivation(0); // Checks wich spawnpoints needs to be activated
        CheckCurrentWave(); // check the enemies alive for the current wave to see if a new wave needs to start
    }

    public void CheckCurrentWave() {
        currentSpawnAmount--;
        if (currentSpawnAmount <= 0) {
            print("newwave");
            StartCoroutine(StartNewWave(timeBetweenWaves));
        }
    }

    IEnumerator StartNewWave(float time) {
        yield return new WaitForSeconds(time);
        CheckWaveStats();
    }

    public void CheckForActivation(int index) {
        for (int i = 0; i < offSpawnList.Count;) {
            if (offSpawnList[i].tag == spawnPointTagArray[index]) {
                offSpawnList[i].GetComponent<Spawner>().spawnManager = GetComponent<SpawnManager>();
                activeSpawnList.Add(offSpawnList[i]);
                offSpawnList.Remove(offSpawnList[i]);
            }
        }
    }

    void AddOffList() {
        for (int i = 0; i < spawnPointArray.Count; i++) {
            offSpawnList.Add(spawnPointArray[i]);
        }
    }

    void CheckWaveStats() {
        ResetSpawnAmount(); //reset the saved amount for the enemies to be spawned
        for (int i = 0; i <= spawnAmount.Count - 1; i++) { // incrases the wave amount depending on the currentwave
            float Calcu = increaseProcentPerWave * waveCount;
            Calcu = Calcu / 100;
            Calcu += 1;
            float temp = (float)spawnAmount[i];
            temp = temp * Calcu;
            spawnAmount[i] = (int)temp;
        }

        SaveSpawnAmount(); // saves the enemie amount that needs to be respawned so it can be reseted if needed
        NewWave(); // starts the new wave
    }

    void SetAmountLength() {
        for (int i = 0; i <= spawnAmount.Count - 1; i++) {
            saveSpawnAmount.Add(0);
            amountForEachSpawner.Add(0);
        }
    }

    void ResetSpawnAmount() {
        for (int i = 0; i <= spawnAmount.Count - 1; i++) {
            spawnAmount[i] = saveSpawnAmount[i];
        }
    }

    void SaveSpawnAmount() {
        for (int i = 0; i < spawnAmount.Count; i++) {
            saveSpawnAmount[i] = spawnAmount[i];
        }
    }

    void NewWave() {

        for (int ii = 0; ii < spawnAmount.Count; ii++) { // distributes the needed to be spawned enmies equally over the spawnpoints and saves it in a list.
            float temp = spawnAmount[ii] / activeSpawnList.Count;
            amountForEachSpawner[ii] = (int)temp;
            if (temp < 1) {
                temp = 1;
            }
            amountForEachSpawner[ii] = (int)temp;
        }

        for (int i = 0; i < amountForEachSpawner.Count; i++) { // because of rounding some counts  might turn out different, so this is set to the amount of enemies to be spawned.
            maxSpawnAmount += (amountForEachSpawner[i] * activeSpawnList.Count);
        }

        for (int i = 0; i < activeSpawnList.Count; i++) { // gives the class to the spawners so it can be accessed later.
            Spawner tempClass = activeSpawnList[i].GetComponent<Spawner>();

            for (int ii = 0; ii <= spawnAmount.Count-1; ii++) { // adds the amount that need to be spawned to the lists.
                tempClass.spawnAmount.Add(amountForEachSpawner[ii]);
            }
        }

        currentSpawnAmount = maxSpawnAmount;
        maxSpawnAmount = 0;

        for (int i = 0; i < activeSpawnList.Count; i++) { //start the spawn Coroutines.
            activeSpawnList[i].GetComponent<Spawner>().counter = 0;
           activeSpawnList[i].GetComponent<Spawner>().StartCoroutine(activeSpawnList[i].GetComponent<Spawner>().Spawning(timeBetweenMinions));
        }
        waveCount++; // adds the wave count.
    }
}