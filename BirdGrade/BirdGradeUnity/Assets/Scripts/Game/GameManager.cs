using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject pauseMenu;
    private bool pause, mainMenu;
    public bool death;
    public GameHud gameHud;
    public GameObject[] destroyList;

    void Start() {
        gameHud = GameObject.FindGameObjectWithTag("HudManager").GetComponent<GameHud>();
    }

    void Update() {
        if (!mainMenu) {
            if (!death) {
                if (Input.GetButtonDown("Cancel")) {
                    if (!pause) {
                        gameHud.Activator(pauseMenu);
                        Pause();
                        pause = true;
                    }
                    else {
                        gameHud.DeActivator(pauseMenu);
                        UnPause();
                        pause = false;
                    }
                }
            }
        }
        else {
            Destroy(gameObject);
        }
    }


    public void LoadScene(string scene) {
        UnPause();
        if(scene == "MainMenu") {  
            for(int i = 0; i <= destroyList.Length-1; i++) {
                Destroy(destroyList[i]);
            }

        }
        else {
            mainMenu = false;
        }
          
        SceneManager.LoadScene(scene);
        if(scene == "MainMenu") {
            mainMenu = true;
        }
        
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
