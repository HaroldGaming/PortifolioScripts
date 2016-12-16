using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudPlayerHealth : MonoBehaviour {

    private string healthString;
    public GameObject hudHealth;

    public void SetHealth(int textNumer) {

        healthString = string.Format("{0}", textNumer);

        hudHealth.GetComponent<Text>().text = healthString;
    }
}
