using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpening : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float openposition;
    private float closedposition;
    private bool isOpening;

    [Header("Audio")]
    [SerializeField] private AK.Wwise.Event doorOpen;
    [SerializeField] private AK.Wwise.Event doorClose;
    private int doormode = 0;
    private int change = 0;

    void Start()
    {
        closedposition = transform.position.z;
        openposition = transform.position.z + offset;
    }

    void Update()
    {
        if (TimeStopControll.activated)
        {
            return;
        }
        Vector3 direction = isOpening ? Vector3.forward : Vector3.back;

        if (PressurePlateTrigger.platepressed)
        {
            isOpening = true;
            if (transform.position.z < openposition)
            {
                doormode = 1;
                transform.Translate(direction * speed * Time.deltaTime);
                if (transform.position.z > openposition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, openposition);
                    doormode = 0;
                }
            }
        }
        else
        {
            isOpening = false;
            if (transform.position.z > closedposition)
            {
                doormode = 2;
                transform.Translate(direction * speed * 2f * Time.deltaTime);
                if (transform.position.z < closedposition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, closedposition);
                    doormode = 0;
                }
            }
        }
        if (doormode == 0 && change > 0)
        {
            doorOpen.Stop(gameObject);
            doorClose.Stop(gameObject);
            change = 0;
        }
        if (doormode == 1 && change <= 1)
        {
            doorClose.Stop(gameObject);
            doorOpen.Post(gameObject);
            change = 2;
        }
        if (doormode == 2 && change == 2 || doormode == 2 && change == 0)
        {
            doorOpen.Stop(gameObject);
            doorClose.Post(gameObject);
            change = 1;
        }
    }
}