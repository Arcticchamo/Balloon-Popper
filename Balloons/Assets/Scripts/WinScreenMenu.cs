using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreenMenu : MonoBehaviour {

	public PlayerScoring m_score;
	public Start_Button m_startButton;
	public Text m_scoreText;
	private int m_updatedScore = 0;
	
	void Awake()
	{
		m_score = GameObject.Find ("In_Game_UI").GetComponent<PlayerScoring> ();
		m_scoreText = GameObject.Find("Score Is").GetComponent<Text> ();
		m_startButton = GameObject.Find ("Game_Start_Menu").GetComponent<Start_Button> ();
		gameObject.SetActive (false);
	}

	public void ShowWinScreen()
	{
		gameObject.SetActive (true);
		m_updatedScore = m_score.GetScore ();
		m_scoreText.text = "Player Score is: " + m_updatedScore.ToString();
	}

	public void HideWinScreen()
	{
		gameObject.SetActive (false);
		m_startButton.ReturnToMenu ();
	}
}
