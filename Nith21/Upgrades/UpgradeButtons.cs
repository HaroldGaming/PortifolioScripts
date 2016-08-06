//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {

	public UpgradeWeapon upgradeScript;
	public GameObject upgradeManager;
	public GameObject currentWeapon;
	public int[] maxUpgrades;
	public bool rayWeapon;
	//public RaycastWeapon weaponScript;
	public Upgraders upgradeIndexer;
	//public int temp;
	public float temper;

	void Start () {
		upgradeScript = upgradeManager.GetComponent<UpgradeWeapon>();
		upgradeIndexer = upgradeManager.GetComponent<Upgraders>();

	}

	void Update () {

	}

	public void UpgradeButton(int index){
		currentWeapon = upgradeScript.currentWeapon;
		upgradeIndexer.GetVariables(currentWeapon);
		upgradeIndexer.CheckClass(GetComponent<UpgradeButtons>(), currentWeapon);
		upgradeScript.currentIndex = index;
		upgradeScript.currentUpgrade = upgradeIndexer.upgradeVariables[index]; //weaponScript.upgradeVariables[index];// 0 = currentWeapon.list[index];
		upgradeScript.Upgrade();
	
		if(rayWeapon){
			if(upgradeScript.currentUpgrade == maxUpgrades[0]){
				upgradeIndexer.maxUpgrades = true;
			}
		}
		else{
			if(upgradeScript.currentUpgrade == maxUpgrades[1]){
				upgradeIndexer.maxUpgrades = true;
			}
		}
		upgradeIndexer.upgradeVariables[index] = upgradeScript.currentUpgrade; // temp = currentenWeapon.list[index];
		upgradeIndexer.SetVariables(currentWeapon);
	}
}
