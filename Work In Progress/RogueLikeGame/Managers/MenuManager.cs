using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{//loads the level in the main menu
    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

}
