using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour {

	void Start()
	{
		HideCanvas();
	}

	public void ShowCanvas()
	{
		this.gameObject.SetActive (true);
	}

	public void HideCanvas()
	{
		gameObject.SetActive (false);
	}
}
