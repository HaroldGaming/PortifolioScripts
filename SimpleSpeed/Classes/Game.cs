using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject deadScreen, pauseMenu;
    public Hud hud;
    public bool mainMenu;
    private bool pause;

    void Start() {
        if (!mainMenu) {
            hud = GameObject.FindGameObjectWithTag("HudObject").GetComponent<Hud>();
        }
        UnPause();
    }

    void Update() {
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

    public void LoadScene(string scene) {
        UnPause();
        SceneManager.LoadScene(scene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Dead() {
        Pause();
        hud.Activator(deadScreen);
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
