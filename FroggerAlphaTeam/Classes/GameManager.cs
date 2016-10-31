using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool pause;
    public bool mainMenu;
    public Hud hud;
    public GameObject pauseMenu, gameOverMenu;


	void Start () {
        if (!mainMenu) {
            hud = GameObject.FindGameObjectWithTag("Hud").GetComponent<Hud>();
        }
	}

    void Update() {
        if (!mainMenu) {
            if (Input.GetButtonDown("Cancel")) {
                if (!pause) {
                    hud.Activator(pauseMenu);
                    Pause();
                    pause = true;
                }
                else {
                    hud.DeActivator(pauseMenu);
                    UnPause();
                    pause = false;
                }
            }
        }
    }

    public void GameOver() {
        hud.Activator(gameOverMenu);
        Pause();
    }

    public void LoadScene(string scene) {
        UnPause();
        SceneManager.LoadScene(scene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void EndLevel() {
        Pause();
        hud.Activator(gameOverMenu);
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
