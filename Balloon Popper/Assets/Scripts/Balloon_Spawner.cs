using UnityEngine;
using System.Collections;

public class Balloon_Spawner : MonoBehaviour {

	public Balloon_Object_Pool m_balloonPool;
	public float m_spawnRate = 2.5f;
	public StatChange_Sliders m_statChange;
	public PlayerScoring m_scorer;
	public InGameUI m_gameUI;

	private bool m_spawnbool = false;
	private bool m_spawnTrigger = false;
	private bool m_gameStart = false;
	private bool m_menuTrigger = true;
	private Transform m_transform;

	

	void Start()
	{
		m_balloonPool = GetComponent<Balloon_Object_Pool>();
		m_statChange = GameObject.Find ("Game_Start_Menu").GetComponent<StatChange_Sliders>();
		m_scorer = GameObject.Find ("In_Game_UI").GetComponent<PlayerScoring> ();
		m_gameUI = GameObject.Find ("In_Game_UI").GetComponent<InGameUI> ();
	}

	void Update()
	{
		if (!m_gameStart && m_menuTrigger) 
		{
			StartCoroutine(MenuSpawner());
			m_menuTrigger = false;
		}

		if (m_spawnTrigger) 
		{
			StopCoroutine(MenuSpawner());
			StartCoroutine(WaitTime());
			m_balloonPool.SetBalloonfeatures(m_statChange.GetSize(), 
			                                 m_statChange.GetSpeed());
			m_spawnRate = m_statChange.GetSpawnTime();
			m_gameUI.ShowCanvas();
			m_scorer.Started();
			m_spawnbool = true;
			StopCoroutine(WaitTime());
			StartCoroutine(SpawnRoutine());
			m_spawnTrigger = false;
			m_gameStart = true;
		}
	}

	IEnumerator WaitTime()//Delay between game Start and 
	{
		yield return new WaitForSeconds(3);
	}

	IEnumerator MenuSpawner()//MenuSpawning Balloons
	{
		yield return new WaitForSeconds(0.3f);
		m_balloonPool.SetBalloonfeatures(m_statChange.GetSize(),
			                                 m_statChange.GetSpeed());
		m_balloonPool.SpawnBalloon(GetPosition());
		if (!m_gameStart)
			StartCoroutine (MenuSpawner());
	
	}

	IEnumerator SpawnRoutine() //In Game Spawning Balloons
	{
		while (m_spawnbool) 
		{
			yield return new WaitForSeconds(m_spawnRate);
			m_balloonPool.SpawnBalloon(GetPosition());
		}
	}

	Vector3 GetPosition()
	{
		float X = Random.Range (-7.95f, 7.95f);
		float Y = -7.0f;
		Vector3 Pos = new Vector3 (X, Y, 0.0f);
		return Pos;
	}

	public void ResetData()
	{
		m_gameStart = false;
		m_menuTrigger = true;
		m_spawnTrigger = false;
		m_spawnbool = false;
		StopCoroutine (SpawnRoutine ());
	}

	public void SetTrigger(bool _trigger)
	{
		m_spawnTrigger = _trigger;
	}
}
