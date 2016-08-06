using UnityEngine;
using System.Collections;

public class ShopHud : MonoBehaviour {

	public ShopManager shopManger;
	public GameObject shopManagerObject;
	public int[] costList;
	public int[] amountList;

	void Start () {
		shopManger = shopManagerObject.GetComponent<ShopManager>();
	}

	void Update () {
		
	}

	public void changeHud(int index){
		
	}
}
