//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public GameObject enemyShooter;
	public float bulletDamage;
	public Rigidbody rb;
	public float bulletSpeed;
	public Transform playerTarget;
	//public Vector3 rotation;

	void Start () {
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		transform.LookAt(playerTarget);
		rb = GetComponent<Rigidbody>();
		Vector3 rotation = transform.eulerAngles;
		float randomNum = Random.Range(-0.001F, 0.001F);
		rotation.y += randomNum;
		rotation.x += randomNum;
		//rotation.z = transform.rotation.z;
		transform.eulerAngles = rotation;
		//rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
	}

	void Update(){
		rb.velocity = transform.forward * bulletSpeed * Time.deltaTime;
		//rb.velocity = new Vector3(0, 0, bulletSpeed);
	}

	void OnCollisionEnter(Collision hit){
		if(hit.transform.tag == "Player"){
			DealDamage(hit.gameObject, bulletDamage);
			Destroy(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}

	void DealDamage(GameObject player, float damage){
		player.GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(damage);
	}
}