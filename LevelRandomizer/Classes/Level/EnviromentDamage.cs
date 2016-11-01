

using UnityEngine;
using System.Collections;

public class EnviromentDamage : MonoBehaviour {

    private float lavaDamage, burnDamage, totalBurnDamage;
    public float burnTime;
    public float overTimePercentageDamage;
    public float instaPercentageDamage;
    public bool burner, inLava;

    void Update() {
        AfterBurner(burner);

        if (inLava) {
            StartCoroutine(Burner(burnTime));
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Lava") {
            inLava = true;
            lavaDamage = GetComponent<PlayerStats>().currentHealth / 100 * instaPercentageDamage; // 200 = currenthealth
            burnDamage = GetComponent<PlayerStats>().maxHealth / burnTime / 100 * overTimePercentageDamage; // 200 = maxhealth
            LavaDamage();
        }
    }

    void OnTriggerExit(Collider other) {
        inLava = false;
    }

    void LavaDamage() {
        GetComponent<PlayerStats>().currentHealth-= lavaDamage;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().DamageCheck(lavaDamage);
    }

    void AfterBurner(bool isBurning) {
        if (isBurning == true) {
            totalBurnDamage += burnDamage * Time.deltaTime;
            if (totalBurnDamage >= 1) {
                GetComponent<PlayerStats>().currentHealth -= lavaDamage * Time.deltaTime;
                GameObject.Find("HealthBar").GetComponent<HealthBar>().DamageCheck(burnDamage);
                totalBurnDamage = 0;
            }
        }

    }

    IEnumerator Burner(float burnTime) {
        burner = true;
        yield return new WaitForSeconds(burnTime);
        burner = false;
    }
}