using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float defaultPosition;
    private float changedPosition;
    bool flag = true;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event spikes;

    void Start()
    {
        changedPosition = transform.position.y + offset;
        defaultPosition = transform.position.y;
    }

    void Update()
    {
        if (!PressurePlateTrigger.platepressed)
        {
            if (TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y >= defaultPosition)
            {
                flag = true;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        if (PressurePlateTrigger.platepressed)
        {
            if (TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y <= changedPosition)
            {

                if (flag)
                {
                    spikes.Post(gameObject);
                    flag = false;
                }
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
