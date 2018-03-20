using UnityEngine;
using System.Collections;

public class Start_Button : MonoBehaviour {

	private Balloon_Spawner m_spawner;
	private int m_gamemode = 1; //1 = Timed // 2 = Infinite

	void Start()
	{
		m_spawner = GameObject.Find ("BalloonPool").GetComponent<Balloon_Spawner> ();
	}

	public void StartGame()
	{
		m_spawner.SetTrigger (true);
		gameObject.SetActive (false);
	}

	public void ReturnToMenu()
	{
		gameObject.SetActive (true);
		m_spawner.ResetData ();
	}

	public void SetTimed()
	{
		m_gamemode = 1;
	}

	public void SetInfinite()
	{
		m_gamemode = 2;
	}

	public int GetGamemode()
	{
		return m_gamemode;
	}

	public void MainMenuLoad()
	{
		Debug.Log ("Main Menu");
		Application.LoadLevel ("Main Menu");
	}
}
