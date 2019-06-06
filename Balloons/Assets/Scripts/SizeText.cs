using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SizeText : MonoBehaviour {

	private Text m_sizeText;
	private StatChange_Sliders m_stats;
	
	void Start()
	{
		m_sizeText = GetComponent<Text> ();
		m_stats = GameObject.Find ("Game_Start_Menu").GetComponent<StatChange_Sliders> ();
	}
	
	void Update()
	{
		m_sizeText.text = "Size = " + m_stats.GetSize().ToString();
	}
}
