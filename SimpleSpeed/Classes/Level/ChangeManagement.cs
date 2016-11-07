using UnityEngine;
using System.Collections;

public class ChangeManagement : MonoBehaviour {

    public GameObject[] formArray;//is for the player ball particles
    public GameObject[] vortexArray;// is for the vortex at the end of each lap
    public Material[] skyArray;// is for the skyboxes
    public float[] changeAmount;//the score amount you need before the scenery changes
    private int counter;
    private bool oneTime;
    private Score score;
    private ObstacleManager obstacles;
    private GameObject camara, player;

	void Start () {//saves vars so that i dont have to keep calling them
        player = GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<Score>();
        obstacles = GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleManager>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        counter = 0;
	}

    public void CheckChange() {//checks wich it needs to set off and wich it needs to activate. if you meet the requirement at the end of a lap.
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
