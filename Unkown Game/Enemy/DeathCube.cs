using UnityEngine;
using System.Collections;

public class DeathCube : MonoBehaviour 
{
	public GameObject player;
	public Rigidbody rb;
	public float timer;
	public GameObject spawnObject;
	public CubeSpawner spawnScript;
	public SpawnCubeMovement spawnMover;
	public float adder;
	public GameObject partical;
	public int pushPower;
	public Vector3 playerPosition;
	public float stunTimer;
	public Vector3 destroyPosition;
	public int waveCounter;
	public GameObject deathAttack;
	public float startDown;
	public GameObject temp;
	
	void Start () 
	{
		player = GameObject.Find("Player");
		rb = player.GetComponent<Rigidbody>();
		spawnObject = GameObject.Find ("SpawnCube");
		spawnScript = spawnObject.GetComponent<CubeSpawner>();
		spawnMover = spawnObject.GetComponent<SpawnCubeMovement>();
		timer = 20;

		waveCounter = spawnScript.waveCounter;

		if(waveCounter == 1)
		{
			StartCoroutine(launchAttack(4));
		}
		
		if(waveCounter == 2)
		{
			StartCoroutine(launchAttack(3));
		}

		if(waveCounter == 3)
		{
			StartCoroutine(launchAttack(2));
		}

		if(waveCounter >= 4)
		{
			StartCoroutine(launchAttack(1));
		}
	}

	void Update () 
	{
		waveCounter = spawnScript.waveCounter;
		destroyPosition = player.transform.position;
		destroyPosition.y -= 20;

		if(transform.position.y <= destroyPosition.y)
		{
			spawnMover.flySpeed+= adder;
			Destroy (gameObject);
		}

		if(transform.position.y >= spawnObject.transform.position.y)
		{
			Destroy (gameObject);
		}

		timer-= Time.deltaTime;

		if(timer <= 0)
		{
			Destroy (gameObject);
		}

	}

	IEnumerator launchAttack(float cooldown) 
	{
		yield return new WaitForSeconds(startDown);
		while(true)
		{
			temp = Instantiate(deathAttack, transform.position, transform.rotation) as GameObject;
			temp.GetComponent<DeathAttack>().spawnScript = spawnScript;

			yield return new WaitForSeconds(cooldown);
		}
	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Instantiate(partical, transform.position, transform.rotation);
			player.GetComponent<BoosterScript>().timer += stunTimer;
			player.GetComponent<BoosterScript>().BoostReset();
			rb.velocity = new Vector3(0, -pushPower, 0);
			Destroy (gameObject);
		}
	}

	public void DeathPartical()
	{
		Instantiate(partical, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
