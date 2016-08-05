using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
	public StuffToSave stuffToSave;
	public GameObject player;
	public GameObject upgradeJect;
	public GoldMaker goldScript;
	public Upgrades upgradeScript;
	public BoosterScript boostScript;
	public HudScript hudScript;

	void Start()
	{
		boostScript = player.GetComponent<BoosterScript>();
		goldScript =  player.GetComponent<GoldMaker>();
		upgradeScript = upgradeJect.GetComponent<Upgrades>();
		hudScript = player.GetComponent<HudScript>();
	}

	public void LoadPress()
	{
		XMLManager xmlManager = new XMLManager ();
		stuffToSave = xmlManager.Load();
		Loader();
	}

	public void SavePress()
	{
		StuffToSave stuffToSave = new StuffToSave ();
		stuffToSave.boost = (int)boostScript.rocketBoostStart;
		stuffToSave.fuel = (int)boostScript.startFuel;
		stuffToSave.gold = goldScript.gold;
		stuffToSave.goldPerMeter = goldScript.getPerMeter;
		stuffToSave.goldCost = upgradeScript.payAmount;
		stuffToSave.goldIncrease = upgradeScript.payIncrease;

		stuffToSave.enumBoostIndex = (int)upgradeScript.boostUpgrade;
		stuffToSave.enumFuelIndex = (int)upgradeScript.fuelUpgrade;
		stuffToSave.enumGoldIndex = (int)upgradeScript.goldUpGrade;
		stuffToSave.highScore = hudScript.highScore;
		
		XMLManager xmlManager= new XMLManager ();
		xmlManager.SaveData (stuffToSave);
	}

	void Loader()
	{
		boostScript.rocketBoostStart = (float)stuffToSave.boost;
		boostScript.startFuel = (float)stuffToSave.fuel;
		goldScript.gold = stuffToSave.gold;
		goldScript.getPerMeter = stuffToSave.goldPerMeter;
		upgradeScript.payAmount = stuffToSave.goldCost;
		upgradeScript.payIncrease = stuffToSave.goldIncrease;
		upgradeScript.boostUpgrade = (Upgrades.BoostUpGrade)stuffToSave.enumBoostIndex;
		upgradeScript.fuelUpgrade = (Upgrades.FuelUpGrade)stuffToSave.enumFuelIndex;
		upgradeScript.goldUpGrade = (Upgrades.GoldUpGrade)stuffToSave.enumGoldIndex;
		hudScript.highScore = stuffToSave.highScore;
	
	}

}
