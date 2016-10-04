using UnityEngine;
using System.Collections;

public class DifficultyCube : MonoBehaviour {

    public int difficultyNumber;
    public GameObject[] cubes;


	void Update () {
	    if(difficultyNumber == 0) {
            cubes[0].SetActive(true);
            cubes[1].SetActive(false);
            cubes[2].SetActive(false);
        }

        if (difficultyNumber == 1) {
            cubes[1].SetActive(true);
            cubes[0].SetActive(false);
            cubes[2].SetActive(false);
        }

        if (difficultyNumber == 2) {
            cubes[2].SetActive(true);
            cubes[1].SetActive(false);
            cubes[0].SetActive(false);
        }
    }
}
