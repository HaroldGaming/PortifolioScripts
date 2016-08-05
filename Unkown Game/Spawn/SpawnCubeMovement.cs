using UnityEngine;
using System.Collections;

public class SpawnCubeMovement : MonoBehaviour 
{
	public Rigidbody rb;
	public float flySpeed;
	public float startSpeed;
	public float increaseSpeed;
	public float maxSpeed;


	void Start () 
	{
		startSpeed = flySpeed;
	}
	

	void Update () 
	{
		rb.velocity = new Vector3(0, flySpeed, 0);
		flySpeed+= increaseSpeed * Time.deltaTime;

		if(flySpeed >= maxSpeed)
		{
			flySpeed = maxSpeed;
		}
	}
}
