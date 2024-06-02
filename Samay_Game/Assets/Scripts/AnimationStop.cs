using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AnimationStop : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material groundWater;
    [SerializeField] private Material Waterfountain;
    [SerializeField] private VFXEventAttribute fire;
    void Start()
    {

    }

    void Update()
    {
        if (TimeStopControll.activated)
        {
            groundWater.SetFloat("RipplesSpeed", 0);
        }
        else
        {
            groundWater.SetFloat("RipplesSpeed", 0.5f);
        }
    }
}
