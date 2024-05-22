using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStop : MonoBehaviour
{
    private Material groundWater;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeStopControll.activated)
        {
            groundWater.SetFloat("RipplesSpeed", 0);
        }
    }
}
