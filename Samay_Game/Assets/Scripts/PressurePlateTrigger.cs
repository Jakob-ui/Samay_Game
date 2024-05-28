using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float notpressedposition;
    private float pressedposition;
    public static bool platepressed = false;
    void Start()
    {
        pressedposition = transform.position.y + offset;
        notpressedposition = transform.position.y;
    }

    void Update()
    {

        if (platepressed)
        {
            if (!TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y >= pressedposition)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        if (!platepressed)
        {
            if (!TimeStopControll.activated)
            {
                return;
            }
            if (transform.position.y <= notpressedposition)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platepressed = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platepressed = false;
        }
    }
}