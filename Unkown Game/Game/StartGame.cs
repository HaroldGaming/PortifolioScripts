using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void GameStart() {
		Application.LoadLevel("LeGame");
	}

	public void MainMenu() {
		Application.LoadLevel("MainMenu");
	}

	public void Quit(){
		Application.Quit();
	}
}
