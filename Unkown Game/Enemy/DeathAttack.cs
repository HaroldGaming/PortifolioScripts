using UnityEngine;
using System.Collections;

public class DeathAttack : MonoBehaviour 
{
	public Rigidbody rb;
	public float pullAmount;
	public CubeSpawner spawnScript;
	public GameObject deathPartical;
	public GameObject player;
	public BoosterScript boostScript;
	public float stunTimer;
	public float timer;

	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
		boostScript = player.GetComponent<BoosterScript>();
		timer = 10;
	}
	

	void Update () 
	{
		rb.velocity = new Vector3(0, pullAmount, 0);

		if(spawnScript.waveCounter == 0)
		{
			Instantiate(deathPartical, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		timer-= Time.deltaTime;

		if(timer <= 0)
		{
			Instantiate(deathPartical, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Instantiate(deathPartical, transform.position, transform.rotation);
			boostScript.timer += stunTimer;
			Destroy(gameObject);
		}
	}
}
