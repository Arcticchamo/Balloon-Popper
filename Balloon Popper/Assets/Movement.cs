using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float m_Speed;

    void Update()
    {
        Vector3 m_Movement = new Vector3(0f, 1f, 0f) * m_Speed * Time.deltaTime; 
        transform.Translate(m_Movement);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Dead");
    }

}
