using UnityEngine;
using System.Collections;

public class CollectPerArea : MonoBehaviour {

    public GameManager gameManager;
    public int maxBirdAmount;
    public string[] sceneList;
    private int currentBirdAmount;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void AddBirdCount() {
        currentBirdAmount++;
        
        if (maxBirdAmount == currentBirdAmount) {
            gameManager.LoadScene(sceneList[0]);
        }

    }
}
