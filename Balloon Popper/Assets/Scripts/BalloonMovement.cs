using UnityEngine;
using System.Collections;

public class BalloonMovement : MonoBehaviour {

	public float m_speed;
	public PlayerScoring m_scoring;
	private Transform m_transform;
	private Vector3 m_movement;

	void Awake()
	{
		m_movement = new Vector3(0.0f, 1.0f, 0.0f);
		m_scoring = GameObject.Find ("In_Game_UI").GetComponent<PlayerScoring> ();
		m_transform = GetComponent<Transform> ();
	}

	void Update()
	{
		if (gameObject.activeSelf) 
		{
			m_transform.Translate(m_movement * m_speed * Time.deltaTime);
		}
	}

	void OnBecameInvisible()
	{
		m_scoring.ResetMulti ();
		gameObject.SetActive (false);
	}

	public void BalloonInit(Vector3 _position)
	{
		gameObject.SetActive (true);
		gameObject.transform.position = _position;
	}

	public void SetSpeed(float _speed)
	{
		m_speed = _speed;
	}

	public void SetSize(float _size)
	{
		gameObject.transform.localScale = new Vector3(_size, _size, 0.0f);
	}
}
