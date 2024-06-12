using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutLevelEnter : MonoBehaviour
{
    public FadeInOut fade;
    [SerializeField] AK.Wwise.Event cavedrips;
    private bool flag = true;
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(Fade());

    }
    void Update()
    {
        if (flag)
        {
            cavedrips.Post(gameObject);
            flag = false;
        }
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }
}
