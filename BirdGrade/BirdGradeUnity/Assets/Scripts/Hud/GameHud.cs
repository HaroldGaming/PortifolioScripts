using UnityEngine;
using System.Collections;

public class GameHud : MonoBehaviour {

    public void Activator(GameObject hudObject) {
        hudObject.SetActive(true);
    }

    public void DeActivator(GameObject hudObject) {
        hudObject.SetActive(false);
    }
}
