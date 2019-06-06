using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerScoring : MonoBehaviour {

   // GlobalStats m_theStats;

    bool m_noTargetMissed = true;
	bool m_gameStart = false;
	bool m_timed = true;
	bool m_startup = false;

    int m_numConsecTargets = 0;
    int m_consecTargetCounter;
    int m_highestConsecTargets;

    int m_numTargetsHit = 0;
    int m_playerScore = 0;

    int m_scoreMultiplier = 100;

    float m_timeRemaining;
	private const float m_timePerRound = 60.0f;

    public Text m_score;
    public Text m_multiplier;
    public Text m_textTimeRemaining;

    TouchInput m_input;
	Start_Button m_button;
	WinScreenMenu m_winScreen;

    //Actions to broadcast to the UI
  //  public Action<int, int> GlobalTargetUpdate = null;
  //  public Action<int, int> GlobalConsecUpdate = null;
  //  public Action<int, int> GlobalScoreUpdate = null;    
  //  public Action<int, float> GlobalTimeUpdate = null;
  //  public Action<int, bool> GlobalNoTargetMissed = null;
	

	void Awake ()
    {
        m_input = GameObject.Find("Main Camera").GetComponent<TouchInput>();
		m_button = GameObject.Find ("Game_Start_Menu").GetComponent<Start_Button> ();
		m_winScreen = GameObject.Find ("Win_Screen").GetComponent<WinScreenMenu> ();
        m_input.ScoreChange += UpdateScore;

      //  m_theStats = GameObject.Find("Global Stats").GetComponent<GlobalStats>();
      //  m_theStats.LinkToGame();

		m_score = GameObject.Find("Timer").GetComponent<Text> ();
		m_multiplier = GameObject.Find("Multiplier").GetComponent<Text> ();
		m_textTimeRemaining = GameObject.Find("Score").GetComponent<Text> ();

		m_timeRemaining = m_timePerRound;
	}

	void Update ()
    {
		if (m_gameStart) 
		{
			if (!m_startup)
			{
				StartUp();
			}

			if (m_timed)
			{
				m_score.text = "Score: " + m_playerScore;
				m_multiplier.text = "Multiplier: " + m_scoreMultiplier;

				m_timeRemaining -= Time.deltaTime;

				m_textTimeRemaining.text = "Time Remaining: " + Mathf.Round (m_timeRemaining);

				if (m_timeRemaining <= 0.0f) 
				{
					Reset();
					m_winScreen.ShowWinScreen();
				}
			}
			else if (!m_timed)
			{
				m_score.text = "Score: " + m_playerScore;
				m_multiplier.text = "Multiplier: " + m_scoreMultiplier;
		
				m_timeRemaining += Time.deltaTime;
			
				m_textTimeRemaining.text = "Time Remaining: " + Mathf.Round (m_timeRemaining);

				//Check When they want to quit 
			}
		}
	}

    void UpdateScore(int _nothing)
    {
        m_playerScore += (int)(100.0f * ((float)m_scoreMultiplier/100.0f));
        m_numTargetsHit++;
        m_numConsecTargets++;
        m_consecTargetCounter++;

        if (m_consecTargetCounter > m_highestConsecTargets)
            m_highestConsecTargets = m_consecTargetCounter;

		Debug.Log (m_numConsecTargets);

        if (m_numConsecTargets >= 10)
        {
			Debug.Log("Increase Multiplier");
            m_scoreMultiplier += 25;

            m_numConsecTargets = 0;
        }
    }

	//Timer Dependant Stuff
	public void Started()
	{
		m_gameStart = true;
	}

	void Reset()
	{
		m_gameStart = false;
		m_startup = false;
		m_timeRemaining = m_timePerRound;
		gameObject.SetActive (false);
	}

	void StartUp()
	{
		m_startup = true;
		if (m_button.GetGamemode() == 1) 
		{
			m_timed = true;
			m_timeRemaining = 60.0f;
		}
		else if (m_button.GetGamemode() == 2)
		{
			m_timed = false;
			m_timeRemaining = 0.0f;
		}
		
	}
	//Timer Dependant Stuff

	public int GetScore()
	{
		return m_playerScore;
	}

    public void ResetMulti()
    {
        m_scoreMultiplier = 100;
        m_consecTargetCounter = 0;
        m_noTargetMissed = false;
    }

    public void QuitGame()
    {
       // GlobalTargetUpdate(1, m_numTargetsHit);
       // GlobalConsecUpdate(1, m_highestConsecTargets);
       // GlobalScoreUpdate(1, m_playerScore);
       // GlobalTimeUpdate(1, 60.0f - m_timeRemaining);
       // GlobalNoTargetMissed(1, m_noTargetMissed);

       // m_theStats.DelinkFromGame();
    }
}