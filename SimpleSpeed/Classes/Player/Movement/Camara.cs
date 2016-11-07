using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

    public PlayerSpeed speed;
    public int[] speedList;
    private int counter;
    public float[] positionList;
    public float camaraMoveSpeed, shakeTimer, shakeIntensity;
    private bool shakeIsOn;
    private float timer;
    private Vector3 savePosition;

	void Start () {
        counter = 0;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpeed>();
	}

    void Update() {
        ChangeCamara();

        if (shakeIsOn) {
            if (timer >= 0) {
                timer -= Time.deltaTime;
                transform.position = Random.insideUnitCircle * shakeIntensity;
            }
            else {
                transform.localPosition = savePosition;
                shakeIsOn = false;
            }
        }
    }

    IEnumerator Shake() {

        float elapsed = 0.0f;

        while (elapsed < timer) {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / timer;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            x *= shakeIntensity * damper;

            transform.localPosition = new Vector3(x, savePosition.y, savePosition.z);

            yield return null;
        }

        Camera.main.transform.localPosition = savePosition;
        shakeIsOn = false;
    }


    public void ObstacleHit() {
        if(shakeIsOn == false) {
            savePosition = transform.localPosition;
        }
        shakeIsOn = true;
        timer = shakeTimer;
        StartCoroutine(Shake());
    }

    void ChangeCamara() {
        if (speed.speed >= speedList[counter]) {
            if (transform.localPosition.z >= positionList[counter]) {
                Vector3 temp = transform.localPosition;
                temp.z -= camaraMoveSpeed * Time.deltaTime;
                transform.localPosition = temp;
            }
            else {
                if (counter < positionList.Length - 1) {
                    counter++;
                }
            }
        }
    }
}
