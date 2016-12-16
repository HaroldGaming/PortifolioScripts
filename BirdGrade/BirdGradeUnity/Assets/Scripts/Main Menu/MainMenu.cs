using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject menu, how;
    
    public void HowToPlay() {
        menu.SetActive(false);
        how.SetActive(true);
    }

    public void Menu() {
        menu.SetActive(true);
        how.SetActive(false);
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
