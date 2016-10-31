using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject deadScreen, pauseMenu, winScreen;
    public Hud hud;
    public bool endless, mainMenu;
    private bool pause;
    public float gameTimer, maxLevelTime;

    void Start() {
        if (!mainMenu) {
            hud = GameObject.FindGameObjectWithTag("HudObject").GetComponent<Hud>();   
        }
        else {
            maxLevelTime = 99999;
        }
        
        if (!endless) {
            gameTimer = maxLevelTime;
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
        if (!mainMenu) {
            TimeCheck();
        }
    }

    void TimeCheck() {
        if (!endless) {
            gameTimer -= Time.deltaTime;
            if(gameTimer <= 0) {
                hud.Activator(winScreen);
                Pause();
            }
        }
        else {
            gameTimer += Time.deltaTime;
        }
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
        hud.Activator(deadScreen);
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
