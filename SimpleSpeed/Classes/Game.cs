using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject deadScreen, pauseMenu;//screen for the pause and dead
    public Hud hud; //to acces the hud
    public bool mainMenu; //to check if its the mainmenu
    private bool pause;

    void Start() {
        if (!mainMenu) {//adds the hud manager into a var if its not the main menu
            hud = GameObject.FindGameObjectWithTag("HudObject").GetComponent<Hud>();
        }
        UnPause();
    }

    void Update() {//pause button and funtion
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

    public void LoadScene(string scene) {//easy way to load scenes with buttons
        UnPause();
        SceneManager.LoadScene(scene);
    }

    public void ExitGame() {//exit game
        Application.Quit();
    }

    public void Dead() {//for if you're dead
        Pause();
        hud.Activator(deadScreen);
    }

    public void Pause() {//pauses the game
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
