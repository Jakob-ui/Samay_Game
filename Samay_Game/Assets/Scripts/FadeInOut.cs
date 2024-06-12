using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private CanvasGroup canvasGroup;
    private bool fadein = false;
    private bool fadeout = false;

    [Header("Time")]
    [SerializeField] private float TimeToFade;
    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if (fadeout == true)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }
    public void FadeOut()
    {
        fadeout = true;
    }
}
