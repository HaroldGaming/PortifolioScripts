using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float startShield, timeBeforeRecharge, barSpeedDown, barSpeedUp, maxShield, currentShield;
    private float increasePerSecond;
    public float chargePerMin;
    public float invisTime, damagaReduction;
    private float timer, timeBeforeHitAllow;
    private bool deathHit;
    public GameObject nearDeathIndicator;
    public Image shieldFillBar;

    void Start() { 
        currentShield = startShield;
        maxShield = startShield;
        deathHit = false;
        increasePerSecond = (chargePerMin / 60);
    }
	
	void Update () {
        if(currentShield > 0) {
            nearDeathIndicator.SetActive(false);
            deathHit = false;
        }

        if(timeBeforeHitAllow >= 0) {
            timeBeforeHitAllow -= Time.deltaTime;
        }

        if(currentShield <= 0) {
            nearDeathIndicator.SetActive(true);
            deathHit = true;
        }
        if(currentShield <= maxShield) {
            ShieldRecharge();
            HudShield();
        }
	}

    void ShieldRecharge() {
        if(timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            if(currentShield <= maxShield) {
                currentShield += increasePerSecond * Time.deltaTime;
            }
            else {
                currentShield = maxShield;
            }
        }
    }

    void HudShield() {
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

    public void GetDamage(float damage) {
        if (timeBeforeHitAllow <= 0) {
            damage = damage / 100 * (100- damagaReduction);
        }
            timer = timeBeforeRecharge;
            timeBeforeHitAllow = invisTime;
            currentShield -= damage;
            CheckDeath(currentShield);
    }

    void CheckDeath(float health) {
        if (deathHit) {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game>().Dead();
        }
    }
}
