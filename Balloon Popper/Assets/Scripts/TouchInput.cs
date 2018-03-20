using UnityEngine;
using System.Collections;
using System;

public class TouchInput : MonoBehaviour {

    bool m_pinchEnabled = false;

    public float m_touchLimit = 250.0f;
    public float m_minTouchDist = 150.0f;

    Vector3 m_touchCentre;

    //Actions to broadcast to the UI
    public Action<int> ScoreChange = null;
	
	void Update ()
    {
        if (Input.touchCount == 2) 
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if ((touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began) && !m_pinchEnabled)
            {
                if (Vector2.Distance(touchZero.position, touchOne.position) < m_minTouchDist)
                {
                    m_pinchEnabled = true;
                    
                    m_touchCentre = (touchZero.position + touchOne.position) / 2;
                }
            }
        }

        if (Input.touchCount < 2 && m_pinchEnabled)
        {
            m_pinchEnabled = false;
            m_touchCentre = new Vector3(0.0f,0.0f,0.0f);
        }

        if (m_pinchEnabled)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (Vector2.Distance(touchZero.position, touchOne.position) > m_touchLimit && (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(m_touchCentre);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


                if (hit != null && hit.collider != null)
                {
                    hit.collider.gameObject.SetActive(false);
                    m_pinchEnabled = false;
                    ScoreChange(1);
                }
            }
        }
	}
}
