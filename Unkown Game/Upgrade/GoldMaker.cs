using UnityEngine;
using System.Collections;

public class GoldMaker : MonoBehaviour 
{
	public float playerPosition;
	public float nextGoldPosition;
	public float nextGoldIncrease;
	public int gold;
	public int getPerMeter;

	void Start()
	{
		playerPosition = transform.position.y;
		nextGoldPosition = transform.position.y + nextGoldIncrease;
	}
	void Update () 
	{
		playerPosition = transform.position.y;

		if( playerPosition >= nextGoldPosition)
		{
			gold+= getPerMeter;
			nextGoldPosition = transform.position.y + nextGoldIncrease;
		}

	}

	public void Reset()
	{
		nextGoldPosition = 0;
	}
}
