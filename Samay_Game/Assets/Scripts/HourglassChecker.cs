using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HourglassChecker : MonoBehaviour
{
    public static bool riddlesolved = false;
    [SerializeField] private Hourglass hourglass0;
    [SerializeField] private Hourglass hourglass1;

    private float finalRotation0 = 270f;
    private float finalRotation1 = 0f;


    void Update()
    {
        if (hourglass0.transform.localRotation.eulerAngles.x == finalRotation0 && hourglass1.transform.localRotation.eulerAngles.x == finalRotation1)
        {
            Debug.Log("Hourglasses correctly rotated!");
            riddlesolved = true;
        }
        else riddlesolved = false;
    }
}
