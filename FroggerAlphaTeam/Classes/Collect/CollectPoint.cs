using UnityEngine;
using System.Collections;

public class CollectPoint : MonoBehaviour {

    private GameObject pickUp;
    public bool chosen;

    void Start() {
        pickUp = this.gameObject.transform.GetChild(0).gameObject;
        pickUp.SetActive(false);
    }

    public void Chosen() {
        chosen = true;
        pickUp.SetActive(true);
    }

    public void Picked() {
        chosen = false;
        pickUp.SetActive(false);
    }
}
