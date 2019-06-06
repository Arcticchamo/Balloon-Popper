using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    private int m_Timer = 0;
    public GameObject m_Balloon;
    private Vector3 m_Position;
    private float m_Random;


    void Update()
    {
        if (m_Timer == 40)
        {
            m_Random = Random.Range(-12f, 12f);
            m_Position = new Vector3(m_Random, -7.5f, 0f);
            Instantiate(m_Balloon, m_Position, Quaternion.identity);
            m_Timer = 0; 
        }
        m_Timer++;
    }
}
