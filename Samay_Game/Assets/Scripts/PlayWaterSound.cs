using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterSound : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event sound;
    private bool flag = true;
    private bool startflag = true;
    void Update()
    {
        if (startflag)
        {
            sound.Post(gameObject);
            startflag = false;
        }
        if (TimeStopControll.activated)
        {
            sound.Stop(gameObject);
            flag = true;
        }
        if (!TimeStopControll.activated)
        {
            if (flag)
            {
                sound.Post(gameObject);
                flag = false;
            }
        }
    }
}
