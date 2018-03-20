using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnTimeText : MonoBehaviour {

	private Text m_spawnTimeText;
	private StatChange_Sliders m_stats;
	
	void Start()
	{
		m_spawnTimeText = GetComponent<Text> ();
		m_stats = GameObject.Find ("Game_Start_Menu").GetComponent<StatChange_Sliders> ();
	}
	
	void Update()
	{
		m_spawnTimeText.text = "SpawnTime = " + m_stats.GetSpawnTime().ToString();
	}
}
