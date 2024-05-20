using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("Pendulum")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float limit = 75f;
    [SerializeField] private float offset = 0;

    private bool isPaused = false;
    private float pausedTime = 0f;
    private float pausedAngle = 0f;

    void Update()
    {

        if (TimeStopControll.activated)
        {
            if (!isPaused)
            {
                float timeSincePause = isPaused ? Time.time - pausedTime : 0f;
                float angle = limit * Mathf.Sin((Time.time + offset - timeSincePause) * speed + pausedAngle);
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
        }
        else
        {
            if (!isPaused)
            {
                pausedTime = Time.time;
                pausedAngle = GetCurrentAngle();
                isPaused = true;
            }
        }

        if (!TimeStopControll.activated && isPaused)
        {
            isPaused = false;
        }

    }

    private float GetCurrentAngle()
    {
        // Calculate the current angle of the pendulum
        float currentAngle = limit * Mathf.Sin((Time.time - pausedTime) * speed + pausedAngle);
        return currentAngle;
    }
}