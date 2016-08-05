using UnityEngine;
using System.Collections;

public class WallHit : MonoBehaviour 
{
	public GameObject player;
	public Rigidbody rb;
	public float pushPower;
	public float stunTimer;

	void Start()
	{
		player = GameObject.Find("Player");
		rb = player.GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(transform.position.x <= 0)
			{
				//Instantiate(partical, transform.position, transform.rotation);
				player.GetComponent<BoosterScript>().timer = stunTimer;
				player.GetComponent<BoosterScript>().BoostReset();
				rb.velocity = new Vector3(+pushPower, 0, 0);
			}
			else
			{
				//Instantiate(partical, transform.position, transform.rotation);
				player.GetComponent<BoosterScript>().timer = stunTimer;
				player.GetComponent<BoosterScript>().BoostReset();
				rb.velocity = new Vector3(-pushPower, 0, 0 );
			}
		}
	}
}
