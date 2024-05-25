using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpening : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float openposition;
    private float closedposition;
    private bool isOpening;

    void Start()
    {
        closedposition = transform.position.z;
        openposition = transform.position.z + offset;
    }

    void Update()
    {
        if (!TimeStopControll.activated)
        {
            return;  // Wenn die Tür gestoppt ist, nichts weiter tun
        }
        Vector3 direction = isOpening ? Vector3.left : Vector3.right;

        if (PressurePlateTrigger.platepressed)
        {
            isOpening = true;
            Debug.Log("Türe öffnen");
            if (transform.position.z < openposition)
            {
                transform.Translate(direction * speed * Time.deltaTime);
                if (transform.position.z > openposition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, openposition);
                }
            }
        }
        else
        {
            isOpening = false;
            Debug.Log("Türe schließen");
            if (transform.position.z > closedposition)
            {
                transform.Translate(direction * speed * 2f * Time.deltaTime);
                if (transform.position.z < closedposition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, closedposition);
                }
            }
        }
    }
}