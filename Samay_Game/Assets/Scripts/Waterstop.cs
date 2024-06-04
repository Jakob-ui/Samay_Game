using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Waterstop : MonoBehaviour
{
    VisualEffect m_WaterPipe;
    Collider m_Collider;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_WaterPipe = GetComponent<VisualEffect>();
    }
    void Update()
    {
        if (TimeStopControll.activated)
        {
            m_Collider.enabled = false;

            if (m_WaterPipe != null)
            {
                m_WaterPipe.SetVector2("Speed-Cylinder-Inside", new Vector2(0, 0.5f));
                m_WaterPipe.SetVector2("Speed-Cylinder-Outside", new Vector2(0, 0.7f));
                m_WaterPipe.SetBool("Is-Alive", true);
            }
        }
        else
        {
            m_Collider.enabled = true;

            if (m_WaterPipe != null)
            {
                m_WaterPipe.SetVector2("Speed-Cylinder-Inside", new Vector2(0, 0));
                m_WaterPipe.SetVector2("Speed-Cylinder-Outside", new Vector2(0, 0));
                m_WaterPipe.SetBool("Is-Alive", false);
            }
        }
    }
}