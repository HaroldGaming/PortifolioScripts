//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyBody : MonoBehaviour {

	public float damageModifier;
	public float calculatedDamage;
	public GameObject mainEnemy;
	public EnemyBaseClass enemyMainHealth;

	public void Damage(float givenDamage){
		//mainEnemy = GameObject.FindGameObjectWithTag("EnemyMain");
		mainEnemy = transform.root.gameObject;

		if(mainEnemy.tag == "TutorialEnemy"){
			GameObject tutorialSpwaner = GameObject.FindGameObjectWithTag("TutorialSpawner");
			TutorialEnemy tutorialSpawnClass = tutorialSpwaner.GetComponent<TutorialEnemy>();
			tutorialSpawnClass.respawn = true;
			Destroy(tutorialSpawnClass.currentEnemy);

		}
		else{
			
			enemyMainHealth = mainEnemy.GetComponent<EnemyBaseClass>();
			calculatedDamage = givenDamage * damageModifier;
			int roundedDamage = Mathf.CeilToInt(calculatedDamage);
			enemyMainHealth.Health(roundedDamage);
		}
	}
}
