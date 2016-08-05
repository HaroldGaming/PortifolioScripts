using UnityEngine;
using System.Collections;

public class SideSpawn : MonoBehaviour
{
	public Vector3 spawnPosition;
	public GameObject wallBlock;
	public GameObject temp;
	public int counter;
	public int maxCounter;
	public bool lastOne;
	public GameObject player;
	public float distanceAmount;
	public float timer;
	public float destroyTime;
	public float distance;
	public float distanceDestroy;
	public GameObject wallObject;

	void Start () 
	{
		Spawn();
		timer = destroyTime;
		player = GameObject.Find("Player");
		//wallObject = GameObject.Find("WallObject");

	}
	
	void Update()
	{
		distance = Vector3.Distance(player.transform.position, transform.position);

		if(lastOne)
		{
			if(distance <= distanceAmount)
			{
				lastOne = false;
				spawnPosition = transform.position;
				spawnPosition.y += transform.localScale.y;
				temp = Instantiate(wallBlock, spawnPosition, transform.rotation) as GameObject;
				temp.GetComponent<SideSpawn>().counter = 0;
				temp.transform.SetParent(wallObject.transform);
			}

		}

		timer-= Time.deltaTime;

		if(distance >= distanceDestroy)
		{
			Destroy (gameObject);
		}

	}

	void Spawn()
	{
		if(counter <= maxCounter)
		{
			spawnPosition = transform.position;
			spawnPosition.y += transform.localScale.y;
			temp = Instantiate(wallBlock, spawnPosition, transform.rotation) as GameObject;
			temp.GetComponent<SideSpawn>().counter++;
			temp.transform.SetParent(wallObject.transform);
		}
		else
		{
			lastOne = true;
		}
	}
}
