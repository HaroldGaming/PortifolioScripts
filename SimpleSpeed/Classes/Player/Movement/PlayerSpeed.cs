using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour {

    public float speed, speedIncrease, increaseIncreaseSpeed, maxSpeed;// your movement speed and the speed it increases every second, this increase has a scaling too.
    public float[] maxSpeedArray, maxIncreaseArray; //to set a sertain max speed for each 'level"
    public int levelCount;
    public bool allowMove;
	
	void Update () {//can disable movement if needed.
        if (allowMove) {
            Move();
            IncreaseSpeed();
        }
    }

    void Move() {//forward movement.
        CheckSpeed();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void CheckSpeed() {//allows the movement speed and increase speed to not go past a sertain amount.
        if(speed >= maxSpeedArray[levelCount]) {
            speed = maxSpeedArray[levelCount];
        }

        if (speedIncrease >= maxSpeedArray[levelCount]) {
            speedIncrease = maxSpeedArray[levelCount];
        }
    }

    void IncreaseSpeed() {//increases the speed and the scaling of the increasing.
        speed += speedIncrease * Time.deltaTime;
        speedIncrease += increaseIncreaseSpeed;
        if(speed >= maxSpeed) {
            speed = maxSpeed;
        }
    }
}
