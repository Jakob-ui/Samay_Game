using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float defaultPosition;
    private float changedPosition;

    void Start()
    {
        changedPosition = transform.position.y + offset;
        defaultPosition = transform.position.y;
    }

    void Update()
    {
        if (!PressurePlateTrigger.platepressed)
        {
            if (!TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y >= defaultPosition)
            {
                Debug.Log("pressed down");
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        if (PressurePlateTrigger.platepressed)
        {
            if (!TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y <= changedPosition)
            {
                Debug.Log("going up");
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
