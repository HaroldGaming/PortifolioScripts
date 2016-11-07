using UnityEngine;
using System.Collections;

public class Turtorial : MonoBehaviour {

    public GameObject[] text;
    public float startBoost;
    private int counter;
    private bool turtorial;


    void Start () {
        counter = 0;
        turtorial = true;
        text[counter].SetActive(true);
	}
	
	void Update () {
        if (turtorial){
            if (Input.GetButtonDown("Submit")) {
                text[counter].SetActive(false);
                if (counter < text.Length-1) {
                    counter++;
                    text[counter].SetActive(true);
                }

                if(counter == text.Length ) {
                    turtorial = false;
                    text[counter].SetActive(false);
                }      
            }

            if (Input.GetButton("Jump")) {
                text[counter].SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpeed>().speed += startBoost;
                turtorial = false;
            }
        }
	}
}
