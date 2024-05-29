using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public static bool platepressed;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PressurePlate"))
        {
            platepressed = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PressurePlate"))
        {
            platepressed = false;

        }
    }
}
