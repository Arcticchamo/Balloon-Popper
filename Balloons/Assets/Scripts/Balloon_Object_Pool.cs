using UnityEngine;
using System.Collections.Generic;

public class Balloon_Object_Pool : MonoBehaviour {

	//4 Different types of balloons
	public GameObject m_redBalloon;
	public GameObject m_blueBalloon;
	public GameObject m_orangeBalloon;
	public GameObject m_purpleBalloon;

	//List to store each balloon
	public List<GameObject> m_balloonPool;

	//Amout of Balloons to spawn
	public int m_amountOfElements; 

	//Number through the list
	private int m_numberInList = 0;

	void Awake()
	{
		m_balloonPool = new List<GameObject> ();

		for (int i = 0; i < m_amountOfElements; i++) 
		{
			GameObject Temp = (GameObject)Instantiate(RandomBalloon());
			Temp.transform.parent = GameObject.Find("BalloonPool").transform;
			Temp.SetActive(false);
			m_balloonPool.Add(Temp);
		}
	}

	GameObject RandomBalloon()
	{
		int RandomNum = Random.Range (1, 5);
		GameObject Temp;

		switch (RandomNum) 
		{
		case 1:
			Temp = m_redBalloon;
			break;
		case 2:
			Temp = m_blueBalloon;
			break;
		case 3:
			Temp = m_orangeBalloon;
			break;
		case 4:
			Temp = m_purpleBalloon;
			break;
		default:
			Temp = m_blueBalloon;
			break;
		}
		return Temp;
	}

	public void SpawnBalloon(Vector3 _position)
	{
		if (m_numberInList >= m_balloonPool.Count)
			m_numberInList = 0;

		for (; m_numberInList < m_balloonPool.Count;) 
		{
			if (!m_balloonPool[m_numberInList].activeInHierarchy)
			{
				m_balloonPool[m_numberInList].GetComponent<BalloonMovement>().BalloonInit(_position);
				m_numberInList++;
				break;
			}
		}
	}

	public void SetBalloonfeatures(float _size, float _speed)
	{
		for (int i = 0; i < m_balloonPool.Count; i++)
		{
			BalloonMovement Temp = m_balloonPool[i].GetComponent<BalloonMovement>();
			Temp.SetSize(_size);
			Temp.SetSpeed(_speed);
		}
	}
}