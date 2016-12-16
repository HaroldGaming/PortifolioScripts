using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int currentHealth;
    public int startHealth;
    private GameManager gameManager;
    public GameObject gameOverScreen;
    private HudPlayerHealth hudHealth;

	void Start () {
        currentHealth = startHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hudHealth = GameObject.FindGameObjectWithTag("HudManager").GetComponent<HudPlayerHealth>();
        hudHealth.SetHealth(currentHealth);

	}
    
    public void GetDamage() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        currentHealth--;
        hudHealth.SetHealth(currentHealth);
        CheckDeath();
    }

    void CheckDeath() {
        if(currentHealth <= 0) {
            gameManager.death = true;
            gameManager.gameHud.Activator(gameOverScreen);
            gameManager.Pause();
        }
    }
}
