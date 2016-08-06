//Gemaakt door Harold

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudBar : MonoBehaviour {

	public GameObject healthBar;
	public float maxBarNumber, currentBarNumber, currentBarAmount, newBarAmount, maxBarAmount;
	public float slideSpeed;
	public float damager;

	void Start () {
		currentBarAmount =  healthBar.GetComponent<Image>().fillAmount;
		newBarAmount = currentBarAmount;
		maxBarAmount = currentBarAmount;
		currentBarNumber = maxBarNumber;
	}


	void Update () {	

		if(newBarAmount < currentBarAmount){
			currentBarAmount-=  0.01F * Time.deltaTime * slideSpeed; 
			healthBar.GetComponent<Image>().fillAmount = currentBarAmount;
		}

		if(newBarAmount > currentBarAmount){
			currentBarAmount+=  0.01F * Time.deltaTime * slideSpeed; 
			healthBar.GetComponent<Image>().fillAmount =currentBarAmount;

		}

		if(currentBarNumber > maxBarNumber)
		{
			currentBarNumber = maxBarNumber;
		}
	
	}

	public void DamageCheck(float barCost){
		if(currentBarNumber <= maxBarNumber){
		currentBarNumber-= barCost;
			newBarAmount = maxBarAmount / maxBarNumber * currentBarNumber;
		}
		else{
			currentBarNumber = maxBarNumber;
		}
	}
}