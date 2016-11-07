using UnityEngine;
using System.Collections;

public class ChangeManagement : MonoBehaviour {

    public GameObject[] formArray;
    public GameObject[] vortexArray;
    public Material[] skyArray;
    public float[] changeAmount;
    private int counter;
    private bool oneTime;
    public Score score;
    private ObstacleManager obstacles;
    private GameObject camara, player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<Score>();
        obstacles = GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleManager>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        counter = 0;
	}

    public void CheckChange() {
        if (counter+1 <= vortexArray.Length - 1) {
            if (changeAmount[counter] <= score.score) {

                player.GetComponent<PlayerSpeed>().levelCount++;

                formArray[counter].SetActive(false);
                vortexArray[counter].SetActive(false);

                obstacles.ChangeObstacles(counter);
                counter++;
                ChangeSky();

                formArray[counter].SetActive(true);
                vortexArray[counter].SetActive(true);
            }
        }
    }

    void ChangeSky() {
        if (counter <= skyArray.Length) {
            camara.GetComponent<Skybox>().material = skyArray[counter-1];
        }
    }
}
