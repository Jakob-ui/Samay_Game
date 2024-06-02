using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterstop : MonoBehaviour
{
    Collider m_Collider;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }
    void Update()
    {
        if (TimeStopControll.activated)
        {
            m_Collider.enabled = false;
        }
        else
        {
            m_Collider.enabled = true;
        }
    }
}
