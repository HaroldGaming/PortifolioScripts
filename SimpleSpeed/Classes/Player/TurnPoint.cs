using UnityEngine;
using System.Collections;

public class TurnPoint : MonoBehaviour {

    public float rotateSpeed, turnTimer, increaseSpeedPerTurn, increaseIncreaseSpeedPerTurn; //rotation speed on turns and the time it maximum takes. and the speed increases you get on the turns.
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

	void Start () {//sets vars so i dont have to add them later, first is only for the start of the game
        first = true;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}

    void Update() {
        if (rotate) {//rotate function for the player
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
        rotate = true;// saves the speeds and increased them and stops the player for moving
        PlayerSpeed speed = GetComponent<PlayerSpeed>();
        speed.allowMove = false;
        saveSpeed = speed.speed;
        saveSpeed += increaseSpeedPerTurn;
        speed.speedIncrease += increaseIncreaseSpeedPerTurn;
    }

    void UnStop() {//lets the player move again and puts back the changed speeds
        PlayerSpeed speed = GetComponent<PlayerSpeed>();
        rotate = false;
        speed.allowMove = true;
        speed.speed = saveSpeed;
        gameObject.transform.rotation = platform.transform.rotation;
    }

    void ActivateStreamList() {//is for the stream list in the particle tunnel with no obstacles. looks better this way
        for(int i = 0; i < streamArray.Length; i++) {
            streamArray[i].SetActive(true);
        }
    }

    void DeActivateStreamList() {///is for the stream list in the particle tunnel with no obstacles. looks better this way
        for (int i = 0; i < streamArray.Length; i++) {
            streamArray[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider turnPoint) {//once you get to the turn point it does the turn function, activates the player particles on the first turn of the game
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

        if(turnPoint.tag == "CheckPoint") {//is for when you reach the checkpoint.
            levelManager.CheckPointGet();
            WarpEffect();
        }
    }

    void WarpEffect() {
        warpParticles.SetActive(true);
    }

    void Rotate(GameObject player, GameObject platform) {//simple lerp rotation
        transform.rotation = Quaternion.Lerp(player.transform.rotation, platform.transform.rotation, Time.deltaTime * rotateSpeed);
    }
}
