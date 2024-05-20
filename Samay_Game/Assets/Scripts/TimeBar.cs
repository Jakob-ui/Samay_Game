using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStrengh(float strengh)
    {
        slider.maxValue = strengh;
        slider.value = strengh;
    }

    public void SetStrengh(float strengh)
    {
        slider.value = strengh;
    }
}
