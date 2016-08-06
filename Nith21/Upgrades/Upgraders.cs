using UnityEngine;
using System.Collections;

public class Upgraders : MonoBehaviour {

	public UpgradeButtons weaponUpgrader;
	public RaycastWeapon raycastClass;
	public ProjectileWeapon projectileClass;
	public UpgradeButtons upgradeButton;
	public UpgradeWeapon weaponScripter;
	public int weaponAmount;
	public int[] upgradeVariables;
	public bool maxUpgrades;

	void Start(){
		weaponScripter = GetComponent<UpgradeWeapon>();
	}

	public void GetVariables(GameObject currentWeapon){
		
		if(currentWeapon.GetComponent<RaycastWeapon>() == currentWeapon.GetComponent<RaycastWeapon>()){
			raycastClass = currentWeapon.GetComponent<RaycastWeapon>();
			upgradeVariables[0] = (int)raycastClass.fireRatePerMinute;
			upgradeVariables[1] = raycastClass.maxPool;
			upgradeVariables[2] = raycastClass.damage;
			upgradeVariables[3] = (int)raycastClass.xSpreadMax;
		}
		else{
			projectileClass = currentWeapon.GetComponent<ProjectileWeapon>();
			upgradeVariables[0] = (int)projectileClass.fireRatePerMinute;
			upgradeVariables[1] = projectileClass.maxPool;
			upgradeVariables[2] = (int)projectileClass.fireSpeed;
			upgradeVariables[3]= projectileClass.grenade.GetComponent<ExplosiveProjectileScript>().enemyDamage;
			upgradeVariables[4]= (int)projectileClass.grenade.GetComponent<ExplosiveProjectileScript>().radius;
			//upgradeVariables[2] = projectileClass.power;
			//upgradeVariables[3] = projectileClass
		}
	}

	public void SetVariables(GameObject currentWeapon){
		if(currentWeapon.GetComponent<RaycastWeapon>() == currentWeapon.GetComponent<RaycastWeapon>()){
			raycastClass.fireRatePerMinute = upgradeVariables[0];
			raycastClass.maxPool = upgradeVariables[1];
			raycastClass.damage =  upgradeVariables[2];
			raycastClass.xSpreadMax = upgradeVariables[3];
			raycastClass.xSpreadMin = upgradeVariables[3];
			raycastClass.ySpreadMax = upgradeVariables[3];
			raycastClass.ySpreadMin = upgradeVariables[3];
			raycastClass.ammoPool -= weaponScripter.tempAmmo;

			if(maxUpgrades){
				raycastClass.allowAltFire = true;//set upgrades true
				maxUpgrades = false;
			}
		}
		else{
			projectileClass.fireRatePerMinute = upgradeVariables[0];
			projectileClass.maxPool = upgradeVariables[1];
			projectileClass.fireSpeed = upgradeVariables[2];
			projectileClass.grenade.GetComponent<ExplosiveProjectileScript>().enemyDamage = upgradeVariables[3]; 
			projectileClass.grenade.GetComponent<ExplosiveProjectileScript>().radius = upgradeVariables[4];
			projectileClass.ammoPool-= weaponScripter.tempAmmo;

			if(maxUpgrades){
				//set upgrades true
				projectileClass.allowAltFire = true;
				maxUpgrades = false;
			}
		}
	}

	public void CheckClass(UpgradeButtons buttonClass, GameObject currentWeapon){
		if(currentWeapon.GetComponent<RaycastWeapon>() == currentWeapon.GetComponent<RaycastWeapon>()){
			buttonClass.rayWeapon = true;
		}
		else{
			buttonClass.rayWeapon = false;
		}
	}
}
