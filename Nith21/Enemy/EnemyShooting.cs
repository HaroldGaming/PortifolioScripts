//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Transform playerTarget;
	public GameObject enemyProjectile, enemyGun;
	public float shootCoolDown;
	public float shootCoolDownReset;
	public Vector3 bulletRotation;
	public float enemyShootDamage;
	public AudioSource audio;
	public AudioClip shoot, randomSound;


	void Start(){
		audio = GetComponent<AudioSource>();

		InvokeRepeating("RandomSound", 3, 4);

		shootCoolDown = shootCoolDownReset;

		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

		enemyGun = gameObject.transform.FindChild("Gun").gameObject;
	}

	void Update() {
		if(Physics.Linecast(transform.position, playerTarget.position)){
			if(shootCoolDown >= 0){
				shootCoolDown -= Time.deltaTime;
			}
			else{
				Shoot();
				GetComponent<EnemieAnimation>().MummyShoot();
				//shootCoolDown =  shootCoolDownReset;
			}
		}
	}

	void Shoot(){
		//bulletRotation = transform.rotation;
		//float randomNum = Random.Range(-0.01, 0.01); 
		//bulletRotation.y+= randomNum;
		audio.PlayOneShot(shoot, 1f);
		GameObject bullet = Instantiate(enemyProjectile, enemyGun.transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<EnemyBullet>().enemyShooter = gameObject;
		bullet.GetComponent<EnemyBullet>().bulletDamage = enemyShootDamage;
		print("pew pew pew");
		shootCoolDown = shootCoolDownReset;
	}

	void RandomSound (){

		audio.PlayOneShot(randomSound, 0.7f);
	}
}
