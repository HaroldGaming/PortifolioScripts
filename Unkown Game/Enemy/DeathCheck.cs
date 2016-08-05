using UnityEngine;
using System.Collections;

public class DeathCheck : MonoBehaviour 
{
	public int lives;
	public int startLives;
	public float playerPosition;
	public float deathPosition;
	public float timer;
	public Vector3 startPosition;
	public int fallAmount;
	public GameObject spawnObject;
	public GameObject craftObject;
	public GameObject spawnCube;

	void Start()
	{
		lives = startLives;
	}

	void Update () 
	{
		if(timer >= 0)
		{
			timer-= 1 * Time.deltaTime;
		}
		else
		{
			playerPosition = transform.position.y;
			timer = 1;


			if(playerPosition >= deathPosition)
			{
				deathPosition = transform.position.y - fallAmount;
			}
		}





		if(playerPosition <= deathPosition)
		{
			GameOver();
		}

		if(lives <= 0)
		{
			GameOver();
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "DeathCube")
		{
			lives-= 1;
		}
	}

	void GameOver()
	{
		print("dead");
		BoosterScript boostScript = GetComponent<BoosterScript>();
		GoldMaker goldScript = GetComponent<GoldMaker>();
		WindowUpgrade upgradeWindow = craftObject.GetComponent<WindowUpgrade>();
		CubeSpawner cubeSpawn = spawnCube.GetComponent<CubeSpawner>();
		SpawnCubeMovement cubeMove = spawnCube.GetComponent<SpawnCubeMovement>();
		cubeSpawn.spawnAllow = false;
		cubeSpawn.KillAll();
		cubeSpawn.counter = 0;
		cubeSpawn.waveCounter = 0;
		cubeSpawn.timerDecrease = 0F;
		cubeSpawn.maxDecTime = cubeSpawn.startDecTime;
		cubeMove.flySpeed = cubeMove.startSpeed;
		spawnCube.transform.position = cubeSpawn.startSpawn;
		upgradeWindow.SetOn();
		transform.position = startPosition;
		goldScript.Reset();
		Destroy(boostScript.wallObject);
		//boostScript.StartAmount();
		boostScript.Pause();

		lives = startLives;
		deathPosition = -10;
	}
}
