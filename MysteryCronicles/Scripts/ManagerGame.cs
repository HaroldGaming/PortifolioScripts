using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour {
	public float versionId = 1.0f;
	public GameStatus gameStatus;

	public AudioSource bgmObject, soundObject;
    public AudioClip[] bgms;	
    float bgmVolume, soundVolume;
    string[] scenes;
    int charID;

	private GameObject uiCanvas;

    // All possible statuses the game can be in.
    public enum GameStatus {
        StartMenu,
        Town,
        Dungeon,
        DungeonBoss,
        DungeonMenu,
        Pause
    };

	private void Start() {
		uiCanvas = GameObject.Find("Canvas_UI");
	}

    // Sounds the background music of the game
    void BGM() {

		if(bgms[(int) gameStatus] && bgmObject.clip != bgms[(int) gameStatus]) {
			bgmObject.clip = bgms[(int) gameStatus];
			bgmObject.Play();
		}
    }

    // Sets the game status of the game and changes the game accordingly
    public void SetStatus(GameStatus status) {
        gameStatus = status;
        
       switch (gameStatus) {
            case GameStatus.StartMenu:		
				uiCanvas.SetActive(false);
				LoadScene("StartMenu");
				Time.timeScale = 0;
				break;
            case GameStatus.Town:
				uiCanvas.SetActive(true);				
				LoadScene("Town");
				Time.timeScale = 1;
				break;
            case GameStatus.Dungeon:
				uiCanvas.SetActive(true);
				FindObjectOfType<DirectionArrow>().DisableArrow();
				LoadScene("LevelScene");
				Time.timeScale = 1;
				break;
            case GameStatus.DungeonBoss:
				Time.timeScale = 1;
				break;
            case GameStatus.DungeonMenu:
				FindObjectOfType<DirectionArrow>().DisableArrow();
				Time.timeScale = 0;
				break;
            case GameStatus.Pause:
				FindObjectOfType<DirectionArrow>().DisableArrow();
				Time.timeScale = 0;
                break;
        }
        BGM();
    }

    // Function to load scenes
    public void LoadScene(string sceneName) {

		if(SceneManager.GetActiveScene().name != sceneName + " " + versionId.ToString("N1")) {
			SceneManager.LoadScene(sceneName + " " + versionId.ToString("N1"), LoadSceneMode.Single);
		}
    }
}
