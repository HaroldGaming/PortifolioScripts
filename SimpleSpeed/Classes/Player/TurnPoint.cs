using UnityEngine;
using System.Collections;

public class TurnPoint : MonoBehaviour {

    public float rotateSpeed, turnTimer, increaseSpeedPerTurn, increaseIncreaseSpeedPerTurn;
    private float saveSpeed, timer;
    public bool rotate;
    private bool streamOn;
    private bool first;
    public GameObject firstForm;
    public GameObject warpParticles;
    private Quaternion saveRotationPlayer, saveRotationPlatform;
    private GameObject platform;
    private LevelManager levelManager;
    public GameObject[] streamArray;

	void Start () {
        first = true;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}

    void Update() {
        if (rotate) {
            if(saveRotationPlayer.y <= saveRotationPlatform.y) {
                Rotate(gameObject, platform);
            }
            
            if(timer <= 0) {
                UnStop();
            }
            else {
                timer -= Time.deltaTime;
            }
        }
    }

    void Stop() {
        rotate = true;
        PlayerSpeed speed = GetComponent<PlayerSpeed>();
        speed.allowMove = false;
        saveSpeed = speed.speed;
        saveSpeed += increaseSpeedPerTurn;
        speed.speedIncrease += increaseIncreaseSpeedPerTurn;
    }

    void UnStop() {
        PlayerSpeed speed = GetComponent<PlayerSpeed>();
        rotate = false;
        speed.allowMove = true;
        speed.speed = saveSpeed;
        gameObject.transform.rotation = platform.transform.rotation;
    }

    void ActivateStreamList() {
        for(int i = 0; i < streamArray.Length; i++) {
            streamArray[i].SetActive(true);
        }
    }

    void DeActivateStreamList() {
        for (int i = 0; i < streamArray.Length; i++) {
            streamArray[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider turnPoint) {
        if (turnPoint.tag == "Turn") {
            if (!streamOn) {
                ActivateStreamList();
                streamOn = true;
            }
            else {
                DeActivateStreamList();
                streamOn = false;
            }
            if (first) {
                firstForm.SetActive(true);
                first = false;
            }
            saveRotationPlayer = transform.rotation;
            saveRotationPlatform = turnPoint.transform.rotation;
            platform = turnPoint.gameObject;
            timer = turnTimer;
            Stop();
        }

        if(turnPoint.tag == "CheckPoint") {
            levelManager.CheckPointGet();
            WarpEffect();
        }
    }

    void WarpEffect() {
        warpParticles.SetActive(true);
    }

    void Rotate(GameObject player, GameObject platform) {
        transform.rotation = Quaternion.Lerp(player.transform.rotation, platform.transform.rotation, Time.deltaTime * rotateSpeed);
    }
}
