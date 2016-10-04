using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public float maxBarNumber;
    private float currentBarNumber, currentBarAmount, newBarAmount, maxBarAmount;
    public float slideSpeed;

    void Start() {
        currentBarAmount = 1;
        newBarAmount = currentBarAmount;
        maxBarAmount = currentBarAmount;
        currentBarNumber = maxBarNumber;
    }


    void Update() {

        if (newBarAmount < currentBarAmount) {
            currentBarAmount -= 0.01F * Time.deltaTime * slideSpeed;
            GetComponent<Scrollbar>().size = currentBarAmount;
        }

        if (newBarAmount > currentBarAmount) {
            currentBarAmount += 0.01F * Time.deltaTime * slideSpeed;
            GetComponent<Scrollbar>().size = currentBarAmount;

        }

        if (currentBarNumber > maxBarNumber) {
            currentBarNumber = maxBarNumber;
        }

        if (newBarAmount == 0) {
            newBarAmount = 1;
            currentBarNumber = maxBarNumber;
        }


    }

    public void DamageCheck(float barCost) {
        if (currentBarNumber <= maxBarNumber) {
            currentBarNumber -= barCost;
            newBarAmount = maxBarAmount / maxBarNumber * currentBarNumber;
        }
        else {
            currentBarNumber = maxBarNumber;
        }
    }
}