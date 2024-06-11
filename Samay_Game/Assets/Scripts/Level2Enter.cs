using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Enter : MonoBehaviour
{
    FadeInOut fade;
    [SerializeField] AK.Wwise.Event rumble;
    void Awake()
    {
        rumble.Post(gameObject);
    }
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }

}
