using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour {

    public float speed, speedIncrease, increaseIncreaseSpeed, maxSpeed;
    public float[] maxSpeedArray, maxIncreaseArray;
    public int levelCount;
    public bool allowMove;
	
	void Update () {
        if (allowMove) {
            Move();
            IncreaseSpeed();
        }
    }

    void Move() {
        CheckSpeed();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void CheckSpeed() {
        if(speed >= maxSpeedArray[levelCount]) {
            speed = maxSpeedArray[levelCount];
        }

        if (speedIncrease >= maxSpeedArray[levelCount]) {
            speedIncrease = maxSpeedArray[levelCount];
        }
    }

    void IncreaseSpeed() {
        speed += speedIncrease * Time.deltaTime;
        speedIncrease += increaseIncreaseSpeed;
        if(speed >= maxSpeed) {
            speed = maxSpeed;
        }
    }
}
