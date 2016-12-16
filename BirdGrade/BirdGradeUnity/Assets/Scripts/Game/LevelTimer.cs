using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {

    private int min;
    private float sec;
    public HudTimer hudTimer;
	
    void Start() {
        hudTimer = GameObject.FindGameObjectWithTag("HudManager").GetComponent<HudTimer>();
    }

	void Update () {
        sec += Time.deltaTime;
        hudTimer.SetSeconds(sec);
        if(sec >= 60) {
            sec = 0;
            min++;
            hudTimer.SetMinutes(min);
        }
	}
}
