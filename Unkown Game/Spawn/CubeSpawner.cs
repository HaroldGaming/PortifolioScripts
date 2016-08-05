using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour 
{
	public Vector3 spawnPosition;
	public GameObject player;
	public GameObject deathCube;
	public Vector3 startSpawn;
	public float timer;
	public float randomNum;
	public float spawnTimer;
	public int mimRange;
	public int maxRange;
	public bool spawnAllow;
	public GameObject[] spawnList;
	public int counter;
	public Vector3 cubeCheck;
	public Vector3 cubePosition;
	public float timerDecrease;
	public int maxDistance;
	public int returnDistance;
	public float maxDecTime;
	public float startDecTime;
	public float addPerTick;
	public int waveCounter;
	public int waveTimer;
	public int number;
	public GameObject partical;
	public GameObject particalWaveClear;
	public Vector3 playerPosition;

	void Start () 
	{
		startSpawn = transform.position;
		timer = spawnTimer;
		spawnAllow = true;
		startDecTime = maxDecTime;
	}
	
	
	void Update () 
	{
		if(spawnAllow)
		{
			if(timer <=0)
			{
				Randomer();
				spawnPosition.x = randomNum;
				//Randomer();
				//spawnPosition.z = randomNum;
				spawnPosition.y = transform.position.y - 2;
				spawnList[counter] = Instantiate(deathCube, spawnPosition, transform.rotation) as GameObject;
				counter++;
				timer = spawnTimer;
			}
			else
			{
				timer -= Time.deltaTime;
			}
		}
		number = spawnList.Length;
		number+= 1;

		waveTimer = number-= counter;

		timerDecrease+= addPerTick * Time.deltaTime;
		timer-= timerDecrease;

		cubeCheck.y = player.transform.position.y+ maxDistance;
		cubePosition = transform.position;

		if(cubePosition.y >=  cubeCheck.y)
		{
			cubePosition.y = player.transform.position.y+ returnDistance;
			transform.position = cubePosition;
		}

		if(counter >= spawnList.Length)
		{
			KillAll();
			waveCounter++;
		}



		if(counter == spawnList.Length)
		{
			counter = 0;
		}

		if(timerDecrease >= maxDecTime)
		{
			timerDecrease = 0;
			maxDecTime+= 1;
		}
	}

	void Randomer()
	{
		randomNum = Random.Range(mimRange, maxRange);
	}

	public void KillAll()
	{
		timerDecrease = 0;

		cubePosition.y = player.transform.position.y+ returnDistance;
		transform.position = cubePosition;
		playerPosition = player.transform.position;
		playerPosition.y+= 10;

		Instantiate (particalWaveClear, playerPosition, player.transform.rotation);

		for (int i = 0; i < spawnList.Length; i++)
		{

			Destroy (spawnList[i]);
			//spawnList[i].GetComponent<DeathCube>().DeathPartical();}
		}
	}
}
