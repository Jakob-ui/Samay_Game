using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformMoveUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private float openposition;
    private float closedposition;
    private bool isOpening;
    private bool playerIsOn;

    void Start()
    {
        closedposition = transform.position.y;
        openposition = transform.position.y + offset;
    }

    void Update()
    {
        if (TimeStopControll.activated)
        {
            return;
        }
        Vector3 direction = isOpening ? Vector3.up : Vector3.down;

        if (HourglassChecker.riddlesolved && playerIsOn)
        {
            isOpening = true;
            if (transform.position.y < openposition)
            {
                transform.Translate(direction * speed * Time.deltaTime);
                if (transform.position.y > openposition)
                {
                    transform.position = new Vector3(transform.position.x, openposition, transform.position.z);
                }
            }
        }
        else
        {
            isOpening = false;
            if (transform.position.y > closedposition)
            {
                transform.Translate(direction * speed * Time.deltaTime);
                if (transform.position.y < closedposition)
                {
                    transform.position = new Vector3(transform.position.x, closedposition, transform.position.z);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOn = false;
        }
    }
}
