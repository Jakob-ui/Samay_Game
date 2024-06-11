using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HourglassChecker : MonoBehaviour
{
    [Header("Hourglasses")]
    public static bool riddlesolved = false;
    [SerializeField] private Hourglass hourglass0;
    [SerializeField] private Hourglass hourglass1;
    private float finalXRotation = 0f;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event success;
    bool flag = true;


    void Update()
    {

        if (hourglass0.transform.localRotation.eulerAngles.x == finalXRotation && hourglass1.transform.localRotation.eulerAngles.x == finalXRotation)
        {
            Debug.Log("Hourglasses correctly rotated!");
            riddlesolved = true;
            if (flag)
            {
                success.Post(gameObject);
                flag = false;
            }

        }

    }


}
