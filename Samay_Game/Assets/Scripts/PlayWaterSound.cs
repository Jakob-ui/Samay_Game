using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterSound : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event cavedrips;
    private bool flag = true;
    void Start()
    {

    }


    void Update()
    {
        if (flag)
        {
            cavedrips.Post(gameObject);
            flag = false;
        }
    }
}
