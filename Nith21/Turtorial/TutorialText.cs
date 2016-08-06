//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {

	public GameObject[] textList;
	public int textCounter;
	public bool textOn;

	void Start () {
		//movement not allowed
		TextActivator();
		textCounter++;
	}

	void Update () {
		if(Input.GetButtonDown("Next")){
			SetFalse();
			if(textCounter < textList.Length+1){
				TextActivator();
			}
				
			if(textCounter == textList.Length+1){
				SetFalse();
				//move allowed
			}
			textCounter++;
		}
	}

	public void TextActivator(){
		if(textCounter < textList.Length){
			print(textCounter);
			textList[textCounter].SetActive(true);

		}
	}

	void SetFalse(){
		for(int i = 0; i < textList.Length; i++){
			textList[i].SetActive(false);
		}
	}

}
