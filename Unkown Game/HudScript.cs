using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour 
{
	public GameObject gradeObject;
	public GameObject spawnObject;
	public string heightNumber;
	public string liveNumber;
	public string goldNumber;
	public string payNumber;
	public string fuelNumber;
	public string highScoreNumber;
	public string waveNumber;
	public string countWaveNumer;
	public float height;
	public int newHeight;
	public int highScore;
	public int gold;
	public int lives;
	public int pay;
	public int fuel;
	public int waveCount;
	public int waveTimer;
	public GameObject liveObject;
	public GameObject heightObject;
	public GameObject goldObject;
	public GameObject payObject;
	public GameObject fuelObject;
	public GameObject highScoreJect;
	public GameObject waveObject;
	public GameObject waveCountObject;
	public BoosterScript boostScript;
	public GoldMaker goldScript;
	public DeathCheck livesScript;
	public Upgrades upgradeScript;
	public CubeSpawner spawnScript;
	
	void Start()
	{
		upgradeScript = gradeObject.GetComponent<Upgrades>();
		goldScript = GetComponent<GoldMaker>();
		livesScript = GetComponent<DeathCheck>();
		boostScript = GetComponent<BoosterScript>();
		spawnScript = spawnObject.GetComponent<CubeSpawner>();
	}

	void Update () 
	{
		fuel = (int)boostScript.fuel;
		gold = goldScript.gold;
		lives = livesScript.lives;
		pay = upgradeScript.payAmount;
		height = transform.position.y;
		newHeight = (int)height;
		waveTimer = spawnScript.waveTimer;
		waveCount = spawnScript.waveCounter;

		if(newHeight >= highScore)
		{
			highScore = newHeight;
		}

		//highScore  = (int)height;
		heightNumber = string.Format("{0}", newHeight);
		liveNumber = string.Format("{0}", lives);
		goldNumber = string.Format("{0}", gold);
		payNumber = string.Format("{0}", pay);
		fuelNumber = string.Format("{0}", fuel);
		highScoreNumber = string.Format("{0}", highScore);
		waveNumber = string.Format("{0}", waveTimer);
		countWaveNumer = string.Format("{0}", waveCount);


		heightObject.GetComponent<Text>().text = heightNumber;
		liveObject.GetComponent<Text>().text = liveNumber;
		goldObject.GetComponent<Text>().text = goldNumber;
		payObject.GetComponent<Text>().text = payNumber;
		fuelObject.GetComponent<Text>().text = fuelNumber;
		highScoreJect.GetComponent<Text>().text = highScoreNumber;
		waveObject.GetComponent<Text>().text = waveNumber;
		waveCountObject.GetComponent<Text>().text = countWaveNumer;





	}
}
