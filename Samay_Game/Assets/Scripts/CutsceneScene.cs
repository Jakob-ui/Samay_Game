using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneScene : MonoBehaviour
{
    [Header("Times")]
    public float changeTime;
    public SceneSwitch scene;
    public FadeInOut fade;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event song;

    [Header("Skip")]
    [SerializeField] TextMeshProUGUI skiptext;
    private bool showskiptext = false;
    private int state = 0;
    private bool skipcutscene = false;
    private float showskiptextTime = 3f;


    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(Fadeout());
        song.Post(gameObject);
        skiptext.enabled = false;
    }
    void Update()
    {
        Debug.Log(showskiptext);
        Debug.Log(state);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 3") || Input.GetKeyDown("joystick button 0"))
        {
            showskiptext = true;
            state += 1;
            if (state == 2)
            {
                skipcutscene = true;
            }
        }


        if (showskiptext)
        {
            skiptext.enabled = true;
            showskiptextTime -= Time.deltaTime;
            if (showskiptextTime <= 0)
            {
                skiptext.enabled = false;
                state = 0;
                showskiptext = false;
                showskiptextTime = 3f;
            }
        }

        if (skipcutscene)
        {
            song.Stop(gameObject);
            StartCoroutine(Fadein());
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            scene.LoadSceneByName("Tutorial");
        }

        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            scene.LoadSceneByName("Tutorial");
        }

    }

    public IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }
    public IEnumerator Fadein()
    {
        yield return new WaitForSeconds(1);
        fade.FadeIn();
    }
}

