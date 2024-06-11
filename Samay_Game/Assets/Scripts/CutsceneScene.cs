using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScene : MonoBehaviour
{
    public float changeTime;
    public SceneSwitch scene;
    public FadeInOut fade;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(Fade());
    }
    void Update()
    {

        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            scene.LoadSceneByName("Tutorial");
        }

    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }
}
