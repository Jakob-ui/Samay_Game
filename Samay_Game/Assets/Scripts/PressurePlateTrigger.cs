using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    private Animator pressurePlateAnimation;
    public static bool platepressed;
    void Start()
    {
        pressurePlateAnimation = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)


    {
        if (other.gameObject.CompareTag("Player"))
        {
            pressurePlateAnimation.SetBool("PressurePlatePressed", true);
            platepressed = true;
            Debug.Log(platepressed);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pressurePlateAnimation.SetBool("PressurePlatePressed", false);
            platepressed = false;
            Debug.Log(platepressed);
        }
    }
}
