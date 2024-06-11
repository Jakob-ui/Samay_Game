using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{

    [Header("Controlls")]
    [SerializeField] private Button support;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event click;
    void Start()
    {
        support.onClick.AddListener(gotosupport);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void gotosupport()
    {
        click.Post(gameObject);
        Application.OpenURL("https://youtu.be/xvFZjo5PgG0?si=-_6A3HI-bXouSMoG");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {

    }
}
