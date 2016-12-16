using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudPoints : MonoBehaviour {
    public GameObject pointObject;
    private string pointString;

    public void Points(int points) {

        pointString = string.Format("{0}", points);

       pointObject.GetComponent<Text>().text = pointString;

    }

}
