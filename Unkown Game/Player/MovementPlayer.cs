using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour 
{
	public bool mayMove;
	public float speed;
	public Vector3 playerPos;



	void Update () 
	{
		if (mayMove) 
		{
			//float translation = Input.GetAxis ("Vertical") * speed;
			float translations = Input.GetAxis ("Horizontal") * speed;
			//translation *= Time.deltaTime;
			translations *= Time.deltaTime;
			//transform.Translate (0, 0, translation);
			transform.Translate (translations, 0, 0);
		}

		playerPos = transform.position;

		if(transform.position.x >= 20)
		{
			playerPos.x-= 1;
			transform.position = playerPos;
		}

		if(transform.position.x <= -20)
		{
			playerPos.x+= 1;
			transform.position = playerPos;
		}

//		if(transform.position.z >= 10)
//		{
//			playerPos.z-= 1;
//			transform.position = playerPos;
//		}
//
//		if(transform.position.z <= -10)
//		{
//			playerPos.z+= 1;
//			transform.position = playerPos;
//		}
		
		
		//float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		//transform.Rotate (0, rotation, 0);
		//rotation *= Time.deltaTime;s
	}
}
