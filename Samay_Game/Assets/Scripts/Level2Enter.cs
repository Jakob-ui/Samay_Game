using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Enter : MonoBehaviour
{
    [Header("Fade Object")]
    FadeInOut fade;
    [Header("Audio")]
    [SerializeField] AK.Wwise.Event rumble;
    void Start()
    {
        rumble.Post(gameObject);
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }

}
