using UnityEngine;
using System.Collections;

public class WindowUpgrade : MonoBehaviour 
{
	public GameObject upgradeWindow;

	void Start () 
	{
		upgradeWindow.SetActive(false);
	}


	public void SetOn()
	{
		upgradeWindow.SetActive(true);
	}

	public void SetOff()
	{
		upgradeWindow.SetActive(false);
	}
}
