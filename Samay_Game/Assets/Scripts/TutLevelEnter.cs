using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutLevelEnter : MonoBehaviour
{
    public FadeInOut fade;
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
