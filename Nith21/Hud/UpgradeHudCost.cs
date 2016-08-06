//Gemaakt door Harold

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeHudCost : MonoBehaviour {

	public string stringCurrentCost;
	public int maxUpgradesCost;
	public int increaseCost;


	public void SetCost(GameObject costObject){
		int currentCost = costObject.GetComponent<CostOnObject>().currentCost;
		currentCost+= increaseCost;
		stringCurrentCost =  string.Format("{0}", currentCost);
		if(currentCost >= maxUpgradesCost){
			stringCurrentCost = "Max";
			costObject.GetComponent<Text>().fontSize = 9;

		}
		costObject.GetComponent<Text>().text = stringCurrentCost;
		costObject.GetComponent<CostOnObject>().currentCost = currentCost;
		//ammoPool = string.Format("{0}", rayCastClass.ammoPool);	
	}
}
