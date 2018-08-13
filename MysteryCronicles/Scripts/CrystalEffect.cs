using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalEffect : MonoBehaviour {

    
    public int collectAmount; // Maximum collect amount for the buff to be activated
    [SerializeField]
    public float buffTime; // Maximum buff time
    [SerializeField]
    private AudioSource soundObj;  // The Audiosource
    [SerializeField]
    private AudioClip buffSound; // Buff sound effect
    [SerializeField]
    private ParticleSystem buffEffect; // Buff particle effect

    private bool buffIsActive;
    private Image crystalBar;
    private Text crystalCounter;
    private int crystalCount, crystalSaveCount;

    // Sets the image and text into a Var, so you can call upon them later. It also sets the crystal count to 0, making sure you dont start off with above 0.
    private void Start() {

        // Sets the variables of the images right.
        crystalBar = GameObject.Find("Energy fill").GetComponent<Image>();
        crystalCounter = GameObject.Find("CrystalCounter").GetComponent<Text>();

        // Sets all counters to 0
        crystalCount = 0;
        crystalCounter.text = crystalCount.ToString();
        crystalBar.fillAmount = 0;
    }

    // This is for the energy bar to deplete
    private void Update() {

        if (buffIsActive) {
            crystalBar.fillAmount -= 1 / buffTime * Time.deltaTime;
        }
    }

    // This function is called when the player picks up a crystal. if you have enough crystals the buff will be activated. While the buff is activated collected will be saved and added after the buff ended.
    public void CheckBuff(GameObject player) {

        if (!buffIsActive) {  

            // Adds a crystal to the counter and sets the number and bar.
            crystalCount++;
            crystalCounter.text = crystalCount.ToString();
            crystalBar.fillAmount = (float)crystalCount / (float)collectAmount;

            // Checks if you have enough crystal to receive the buff
            if (crystalCount >= collectAmount) {
                StartCoroutine(AddBuff(player));
                crystalCount = 0;
                crystalCounter.text = crystalCount.ToString();
            }
        }
        else {

            // Saves crystals if you pick them up during a buff
            crystalSaveCount++;
            crystalCounter.text = crystalSaveCount.ToString();
        }
    }

    // Starts the buff timer and the bar depletion.
    IEnumerator AddBuff(GameObject player) {
        float tempCalculation = 1 / (buffTime * 10F);
        buffIsActive = true;
        player.GetComponentInChildren<Archer>().CrystalBuff(true);
        yield return new WaitForSeconds(buffTime);
        player.GetComponentInChildren<Archer>().CrystalBuff(false);
        buffIsActive = false;
        SetCrystalCount();
    }

    // Adds the saved crystals you picked up during the buff and adds it to the normal count. It also sets the bar correctly.
    void SetCrystalCount() {
        crystalCount = crystalSaveCount;
        crystalBar.fillAmount = (float)crystalCount / (float)collectAmount;
        crystalCounter.text = crystalCount.ToString();
        crystalSaveCount = 0;
    }
}
