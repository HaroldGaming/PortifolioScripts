using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudTimer : MonoBehaviour {

    public GameObject hudSec, hudMin;
    private string seconds, minutes;

	public void SetSeconds(float sec) {
        seconds = string.Format("{0}", (int)sec);

        hudSec.GetComponent<Text>().text = seconds;
    }

    public void SetMinutes(int min) {
        minutes = string.Format("{0}", min);

        hudMin.GetComponent<Text>().text = minutes;
    }
}
