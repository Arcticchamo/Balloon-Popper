using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatChange_Sliders : MonoBehaviour {
	
	private float m_speed = 1;
	private float m_size = 0.3f;
	private float m_spawnTime = 7;
	private Slider m_sizeSlider;
	private Slider m_speedSlider;
	private Slider m_spawnTimeSlider;

	void Start()
	{
		m_sizeSlider = GameObject.Find ("Size").GetComponent<Slider> ();
		m_speedSlider = GameObject.Find ("Speed").GetComponent<Slider> ();
		m_spawnTimeSlider = GameObject.Find ("Spawn Time").GetComponent<Slider> ();
	}

	public void ChangeSize(float _size)
	{
		m_size = _size;
	}

	public float GetSize()
	{
		return m_size;
	}

	public void ChangeSpeed(float _speed)
	{
		m_speed = _speed;
	}

	public float GetSpeed()
	{
		return m_speed;
	}

	public void ChangeSpawnTime(float _time)
	{
		m_spawnTime = _time;
	}

	public float GetSpawnTime()
	{
		return m_spawnTime;
	}

	public void EasySettings()
	{
		m_speed = 1.0f;
		m_size = 0.3f;
		m_spawnTime = 7.0f;
		m_speedSlider.value = 1.0f;
		m_sizeSlider.value = 0.3f;
		m_spawnTimeSlider.value = 7.0f;
	}

	public void MediumSettings()
	{
		m_speed = 2.0f;
		m_size = 0.5f;
		m_spawnTime = 4.0f;
		m_sizeSlider.value = m_size;
		m_speedSlider.value = m_speed;
		m_spawnTimeSlider.value = m_spawnTime;
	}

	public void HardSettings()
	{
		m_speed = 3.0f;
		m_size = 0.7f;
		m_spawnTime = 2.0f; 
		m_sizeSlider.value = 0.7f;
		m_speedSlider.value = 3.0f;
		m_spawnTimeSlider.value = 2.0f;
	}
}
