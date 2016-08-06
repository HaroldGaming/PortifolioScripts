//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class Environment : MonoBehaviour {

	public float lavaDamage;
	public float burnDamage;
	public float burnTime;
	public float  overTimePercentageDamage;
	public float instaPercentageDamage;
	public float totalLavaDamage; // remove later
	public float totalBurnDamage;
	public bool burner, inLava;

	void Update(){
		AfterBurner(burner);

		if(inLava){
			print("onfire");
			StartCoroutine(Burner(burnTime));
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.tag == "Lava"){
			inLava = true;
			lavaDamage = GetComponent<Health_TakeDamage_HitLocation>().playerHealth / 100 * instaPercentageDamage; // 200 = currenthealth
			burnDamage = GetComponent<Health_TakeDamage_HitLocation>().maxHealth / burnTime / 100 * overTimePercentageDamage; // 200 = maxhealth
			LavaDamage();
		}
	}

	void OnTriggerExit(Collider other){
		inLava = false;
	}

	void LavaDamage(){
		//GetComponent<healthscript>().health-= lavaDamage;
		totalLavaDamage += lavaDamage; // remove later
	}

	void AfterBurner(bool isBurning){
		if(isBurning == true){
			totalBurnDamage+= burnDamage * Time.deltaTime;
			if(totalBurnDamage >= 1){
				GetComponent<Health_TakeDamage_HitLocation>().playerHealth -= lavaDamage * Time.deltaTime;
				GameObject.Find("HealthBar").GetComponent<HudBar>().DamageCheck(lavaDamage * Time.deltaTime);
				print("Ouch"); // remove later
				totalBurnDamage = 0;

			}
			//print(totalBurnDamage);
		}

	}

	IEnumerator Burner(float burnTime) {
		burner = true;
		yield return new WaitForSeconds(burnTime);
		burner = false;
	}
}