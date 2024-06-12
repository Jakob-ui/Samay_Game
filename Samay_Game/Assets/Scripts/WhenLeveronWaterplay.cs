using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenLeveronWaterplay : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event waterflow;
    private bool flagon = true;
    private bool flagoff = true;
    private bool flag = true;

    void Start()
    {
        waterflow.Stop(gameObject);
    }


    void Update()
    {
        if (TimeStopControll.activated)
        {
            waterflow.Stop(gameObject);
            flagon = true;
        }
        if (!TimeStopControll.activated)
        {
            if (flag)
            {
                waterflow.Stop(gameObject);
                flag = false;
            }
            if (WaterLever.waterState && flagon)
            {
                waterflow.Post(gameObject);
                flagon = false;
                flagoff = true;
            }
            if (!WaterLever.waterState && flagoff)
            {
                waterflow.Stop(gameObject);
                flagoff = false;
                flagon = true;
            }
        }
    }
}
