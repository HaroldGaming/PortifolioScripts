//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class UpgradeWeapon : MonoBehaviour {

	public int[] upgradeIndex, upgradeCostIndex;
	public int[] pistolList, launcherList, riffleList, smgList;
	public int[] currentUpgradeCount;
	public int currentUpgrade;
	public GameObject currentWeapon;
	public int forNumber, afterForNumber, upgradeAmount, currentIndex;
	public int tempAmmo;
	public GameObject shopObject;
	public ShopHud shopChangeScript;

	void Start () {
		//tempAmmo = 9999;
		//shopChangeScript = shopObject.GetComponent<ShopHud>();
	}

	void Update () {

	}

	public void Upgrade(){
		CheckWhatList();
		forNumber = currentIndex * upgradeAmount;
		currentUpgradeCount[currentIndex]++;
		for(int i = forNumber; i <= upgradeIndex.Length; i++){
			if(upgradeIndex[i] > currentUpgrade){
				if(tempAmmo >= upgradeIndex[i]){
					currentUpgrade = upgradeIndex[i];
					tempAmmo = upgradeCostIndex[i];//9999 = currentWeapon.ammo
				}
				else{
					currentUpgradeCount[currentIndex]--;
				}
				afterForNumber = i;
				Debug.Log(currentUpgrade);
				break;
			}
		}
		afterForNumber++;
		//shopChangeScript.changeHud(afterForNumber);
	}

	void CheckWhatList(){
		if(currentWeapon.transform.tag == "0"){
			for(int i = 0; i < pistolList.Length; i++){
				upgradeIndex[i] = pistolList[i];
			}
		}

		if(currentWeapon.transform.tag == "1"){
			for(int i = 0; i < pistolList.Length; i++){
				upgradeIndex[i] = riffleList[i];
			}
		}

		if(currentWeapon.transform.tag == "2"){
			for(int i = 0; i < pistolList.Length; i++){
				upgradeIndex[i] = smgList[i];
			}
		}

		if(currentWeapon.transform.tag == "3"){
			for(int i = 0; i < pistolList.Length; i++){
				upgradeIndex[i] = launcherList[i];
			}
		}

	}
}
