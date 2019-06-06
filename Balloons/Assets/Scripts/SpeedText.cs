using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedText : MonoBehaviour {
	private Text m_speedText;
	private StatChange_Sliders m_stats;

	void Start()
	{
		m_speedText = GetComponent<Text> ();
		m_stats = GameObject.Find ("Game_Start_Menu").GetComponent<StatChange_Sliders> ();
	}

	void Update()
	{
		m_speedText.text = "Speed = " + m_stats.GetSpeed().ToString();
	}
}
