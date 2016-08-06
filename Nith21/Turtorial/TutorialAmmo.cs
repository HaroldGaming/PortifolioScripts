//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class TutorialAmmo : MonoBehaviour {

	public GameObject currentWeapon;
	public RaycastWeapon weaponScript;
	public  float time, waitTime;

	void Start (){ 
		currentWeapon = GameObject.FindGameObjectWithTag("0");
		weaponScript = currentWeapon.GetComponent<RaycastWeapon>();
	}

	void Update (){
		if(time >= 0){
			time-= Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(time <= 0){
				weaponScript.ammoPool = weaponScript.maxPool;
				time = waitTime;
			}
		}
	}

	void respawnAmmo(){
		
	}
}
