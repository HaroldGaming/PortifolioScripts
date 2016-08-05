using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour 
{
	public GameObject player;
	public GameObject spawnCube;
	public CubeSpawner spawnScript;
	public GoldMaker goldScript;
	public BoosterScript boostScript;
	public GoldUpGrade goldUpGrade;
	public FuelUpGrade fuelUpgrade;
	public BoostUpGrade boostUpgrade;
	public WindowUpgrade windowUpgrade;
	public int number;
	public int[] goldIncrease;
	public int[] fuelIncrease;
	public int[] boostIncrease;
	public int payAmount;
	public int payIncrease;
	public GameObject[] button;

	void Start()
	{
		windowUpgrade = GetComponent<WindowUpgrade>();
		goldScript = player.GetComponent<GoldMaker>();
		boostScript = player.GetComponent<BoosterScript>();
		spawnScript = spawnCube.GetComponent<CubeSpawner>();

	}

	public enum GoldUpGrade
	{
		GoldGrade0,
		GoldGrade1,
		GoldGrade2,
		GoldGrade3
	}

	public enum FuelUpGrade
	{
		FuelGrade0,
		FuelGrade1,
		FuelGrade2,
		FuelGrade3
	}

	public enum BoostUpGrade
	{
		BoostGrade0,
		BoostGrade1,
		BoostGrade2,
		BoostGrade3
	}


	public void PickGold()
	{
		if(goldScript.gold >= payAmount)
		{
			number  = (int)goldUpGrade;
			int maxTemp = (int)GoldUpGrade.GoldGrade3;

			if(number < maxTemp)
			{
				number++;
				goldUpGrade = (GoldUpGrade)number;
			}

			CheckGold();
			Paying();
		}
	
	}

	public void PickFuel()
	{
		if(goldScript.gold >= payAmount)
		{
			number  = (int)fuelUpgrade;
			int maxTemp = (int)FuelUpGrade.FuelGrade3;

			if(number < maxTemp)
			{
				number++;
				fuelUpgrade = (FuelUpGrade)number;
			}

			CheckFuel();
			Paying();

		}
	}

	public void PickBoost()
	{
		if(goldScript.gold >= payAmount)
		{
			number = (int)boostUpgrade;
			int maxTemp = (int)BoostUpGrade.BoostGrade3;

			if(number < maxTemp)
			{
				number++;
				boostUpgrade = (BoostUpGrade)number;
			}

			CheckBoost();
			Paying();
		}
	}

	void Paying()
	{
		goldScript.gold-= payAmount;
		payAmount += payIncrease;
		payIncrease *= 2;
	}

	public void PickDone()
	{
		boostScript.ReStart();
		windowUpgrade.SetOff();
		spawnScript.spawnAllow = true;

	}

	void CheckGold()
	{
		goldScript.getPerMeter = goldIncrease[number-1];

		if(number == 3)
		{
			button[0].SetActive(false);
		}
	}

	void CheckFuel()
	{
		boostScript.startFuel = fuelIncrease[number-1];

		if(number == 3)
		{

			button[1].SetActive(false);
		}
	}

	void CheckBoost()
	{
		boostScript.rocketBoostStart = boostIncrease[number-1];

		if(number == 3)
		{
			button[2].SetActive(false);
		}
	}

}
