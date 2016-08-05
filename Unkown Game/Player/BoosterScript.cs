using UnityEngine;
using System.Collections;

public class BoosterScript : MonoBehaviour 
{
	public Rigidbody rb;
	public float startBoost;
	public float rocketBoost;
	public float rocketBoostStart;
	public float rocketBoostHoldBonus;
	public float timer;
	public float startTimer;
	public float fuel;
	public float startFuel;
	public float startFuelCost;
	public float fuelCost;
	public Vector3 startPosition;
	public GameObject[] particalsFab;
	public GameObject[] particalsGame;
	public Vector3 particalSpawnPosition;
	public GameObject wallCube;
	public Vector3 cubeSpawnPosition1;
	public Vector3 cubeSpawnPosition2;
	public GameObject wallObjectSpawn;
	public GameObject wallObject;
	public GameObject temp;
	
	void Start () 
	{
		particalSpawnPosition = transform.position;
		//particalSpawnPosition.y-= 1F;

		startPosition = transform.position;

		rocketBoost = rocketBoostStart;

		rb = GetComponent<Rigidbody>();

		rb.velocity = new Vector3(0, startBoost, 0);

		timer = startTimer;

		fuel = startFuel;

		fuelCost = startFuelCost;

		WallSpawn();

		ParticalsSpawn();
	}
	

	void Update () 
	{
		if(timer <= 0)
		{
			if(Input.GetButton("Jump"))
			{
				Boost();

			}
			else
			{
				BoostDown();
			}
		}

		if(timer >= 0)
		{
			timer-= Time.deltaTime;
		}
	}
	 void Boost()
	{
		//if(timer <= 0)
		//{
			if(fuel >= 0)
			{
				rb.velocity = new Vector3(0, rocketBoost, 0);
				fuel-= fuelCost * Time.deltaTime;
				rocketBoost+= rocketBoostHoldBonus *Time.deltaTime;
				fuelCost += Time.deltaTime;
			}
		//}
	}

	public void StartAmount()
	{
		fuel = startFuel;
		rocketBoost = rocketBoostStart;
		fuelCost = startFuelCost;
	}

	public void StartBoost()
	{
		//	rb.constraints = ;

		rb.velocity = new Vector3(0, startBoost, 0);
		
		timer = startTimer;
	}

	void BoostDown()
	{
		if(rocketBoost >= rocketBoostStart)
		{
			rocketBoost-= rocketBoostHoldBonus * Time.deltaTime;
		}
		else
		{
			BoostReset();
		}

		if(fuel >= startFuelCost)
		{
			fuelCost -= Time.deltaTime;
		}
		else
		{
			BoostReset();
		}
	}

	public void BoostReset()
	{
		fuelCost = startFuelCost;
		rocketBoost = rocketBoostStart;
	}

	public void Pause()
	{
		Destroy (particalsGame[0]);
		Destroy (particalsGame[1]);
		fuel = 0;
		rocketBoost = 0;
		fuelCost = 0;
		Time.timeScale = 0;
	}

	public void ReStart()
	{
		ParticalsSpawn();
		StartAmount();
		Time.timeScale = 1;
		StartBoost();
		WallSpawn();
	}

	void WallSpawn()
	{
		temp = Instantiate(wallObjectSpawn, transform.position, transform.rotation) as GameObject;
		wallObject = temp;
		temp = Instantiate(wallCube, cubeSpawnPosition1, transform.rotation) as GameObject;
		temp.GetComponent<SideSpawn>().wallObject = wallObject;
		temp.transform.SetParent(wallObject.transform);
		temp = Instantiate(wallCube, cubeSpawnPosition2, transform.rotation) as GameObject;
		temp.GetComponent<SideSpawn>().wallObject = wallObject;
		temp.transform.SetParent(wallObject.transform);
	}

	void ParticalsSpawn()
	{
		particalsGame[0] = Instantiate(particalsFab[0], particalSpawnPosition, transform.rotation) as GameObject;
		particalsGame[1] = Instantiate(particalsFab[1], particalSpawnPosition, transform.rotation) as GameObject;
		particalsGame[0].transform.SetParent(transform);
		particalsGame[1].transform.SetParent(transform);
	}
}
