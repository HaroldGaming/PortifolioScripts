using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float startShield, timeBeforeRecharge, barSpeedDown, barSpeedUp, maxShield, currentShield;// for your starting shield, time till the shield recharges again. speeds for the hud healthbar and the stats for your max and current shield.
    private float increasePerSecond;
    public float chargePerMin; // how much shield charge per min
    public float invisTime, damagaReduction; // timebetween getting hit gives a damage reduction
    private float timer, timeBeforeHitAllow;
    private bool deathHit;
    public GameObject nearDeathIndicator;//indicator for when you're almost dead
    public Image shieldFillBar; //shieldbar for the hud

    void Start() { // set the variables i need to use later.
        currentShield = startShield;
        maxShield = startShield;
        deathHit = false;
        increasePerSecond = (chargePerMin / 60);
    }
	
	void Update () {
        if(currentShield > 0) {// checks if you are on your last hit or not
            nearDeathIndicator.SetActive(false);
            deathHit = false;
        }

        if(timeBeforeHitAllow >= 0) {// your basic timer for reduced damage
            timeBeforeHitAllow -= Time.deltaTime;
        }

        if(currentShield <= 0) { //  checks if you are on your last hit or not
            nearDeathIndicator.SetActive(true);
            deathHit = true;
        }
        if(currentShield <= maxShield) { //if your shield is below max the hud and shield recharges will be activated
            ShieldRecharge();
            HudShield();
        }
	}

    void ShieldRecharge() {
        if(timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            if(currentShield <= maxShield) {//increased your shield per second.
                currentShield += increasePerSecond * Time.deltaTime;
            }
            else {// makes sure it doesn't come above the max
                currentShield = maxShield;
            }
        }
    }

    void HudShield() {//this function is setting the slider on the image. it will gaing and deplate with a simple formula check
        float newBar = (1 / maxShield * currentShield);
        if(newBar <= 0) {
            newBar = 0;
        }
        float currentBar = shieldFillBar.fillAmount;
        if (currentBar >= newBar) {
            if (currentBar >= 0) {
                if (timer >= 0) {
                    currentBar -= barSpeedDown * Time.deltaTime;
                }
            }
            else {
                currentBar = 0;
            }
        }
        else {
            if(currentBar <= 1) {
                if (currentBar <= newBar) {
                    if (timer <= 0) {
                        currentBar += barSpeedUp * Time.deltaTime;
                    }
                }
            }
            else {
                currentBar = 1;
            }
        }
        shieldFillBar.fillAmount = currentBar;
    }

    public void GetDamage(float damage) {//player getting damaged, there is a damage reduction if you get hit again before x seconds have past.
        if (timeBeforeHitAllow >= 0) {
            damage = damage / 100 * (100- damagaReduction);
        }
            timer = timeBeforeRecharge;
            timeBeforeHitAllow = invisTime;
            currentShield -= damage;
            CheckDeath(currentShield);
    }

    void CheckDeath(float health) {//is for the death screen.
        if (deathHit) {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game>().Dead();
        }
    }
}
