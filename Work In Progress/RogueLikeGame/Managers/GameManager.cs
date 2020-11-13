using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public GameObject player;
    private Player playerClass;

    [SerializeField]
    private string[] levelNameList;
    [SerializeField]
    private string currentLevelName;
    [SerializeField]
    private int currentLevelNumber;

    public void Awake() {     
        //Check if a game manager already exists, if so destroy self   
        string tagg = transform.tag;
        print(tagg);

        if(GameObject.FindGameObjectsWithTag(tagg).Length <= 1) {
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
 
        playerClass = player.GetComponent<Player>();       
    }

    public void SetCurrentLevelName(int worldNumber) {//sets the current level name for the next level loader
        currentLevelName = levelNameList[worldNumber];
    }

    public void LoadNextLevel() {//Loads in the next level of the series, optimize later
        currentLevelNumber++;
        string newLevel = currentLevelName + " " + (currentLevelNumber);
        print(newLevel);
        SceneManager.LoadScene(newLevel);
    }

    public void SavePlayer() {//saves the player data
        SaveSystem.SavePlayer(playerClass);
    }

    public void LoadPlayer() {//loads the player data
        PlayerData data = SaveSystem.LoadPlayer();

        playerClass.level = data.level;
        playerClass.health = data.health;
    }    
}
