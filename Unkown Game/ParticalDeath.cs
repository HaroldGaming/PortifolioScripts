using UnityEngine;
using System.Collections;

public class ParticalDeath : MonoBehaviour 
{

	public float timer;

	void Start()
	{
		timer = 6;
	}

	void Update ()
	{
		timer-= Time.deltaTime;

		if(timer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
