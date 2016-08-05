using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour 
{
	public GameObject player;
	public float offset;
	public float distance;
	public float distanceAmount;
	
	void Start () 
	{
		player = GameObject.Find("Player");
	}
	
	void Update () 
	{
		if(distance <= distanceAmount)
		{
			Vector3 tempPos = transform.position;
			tempPos.y = player.transform.position.y + offset;
			transform.position = tempPos;
		}
	}
}
