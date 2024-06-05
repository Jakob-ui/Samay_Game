using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HourglassChecker : MonoBehaviour
{
    public UnityEvent onHourglassesCorrectlyRotated;

    [SerializeField] private Hourglass hourglass0;
    [SerializeField] private Hourglass hourglass1;

    private float finalRotation = 270f;

    void Update()
    {
        if (hourglass0.transform.localRotation.eulerAngles.x == finalRotation && hourglass1.transform.localRotation.eulerAngles.x == finalRotation)
        {
            Debug.Log("Hourglasses correctly rotated!");
            onHourglassesCorrectlyRotated.Invoke();
        }
    }
}
