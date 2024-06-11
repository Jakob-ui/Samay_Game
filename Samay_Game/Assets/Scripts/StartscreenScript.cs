using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StartscreenScript : MonoBehaviour
{
    [Header("Controlls")]
    [SerializeField] private Button start;
    [SerializeField] private Button controlls;
    [SerializeField] private Button quit;
    [SerializeField] private Button back;
    [SerializeField] float timeToSwitchScenes = 1.5f;
    private bool gamestart = false;
    public SceneSwitch scene;
    public FadeInOut fade;
    public GameObject controllCanvas;
    public static bool isPaused = false;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event click;
    [SerializeField] AK.Wwise.Event ambienceplay;
    [SerializeField] AK.Wwise.Event ambiencestop;

    void Start()
    {
        ambienceplay.Post(gameObject);
        start.onClick.AddListener(StartGame);
        controlls.onClick.AddListener(Controlls);
        quit.onClick.AddListener(QuitGame);
        back.onClick.AddListener(Back);
        controllCanvas.SetActive(false);
        fade = FindObjectOfType<FadeInOut>();

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (gamestart)
        {
            timeToSwitchScenes -= Time.deltaTime;
            if (timeToSwitchScenes <= 0)
            {
                scene.LoadSceneByName("Cutscene");
            }
        }
    }

    public void StartGame()
    {
        ambiencestop.Post(gameObject);
        click.Post(gameObject);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        Debug.Log("Starting Game...");
        fade.FadeIn();
        gamestart = true;
    }

    void Controlls()
    {
        click.Post(gameObject);
        controllCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        click.Post(gameObject);
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Back()
    {
        click.Post(gameObject);
        controllCanvas.SetActive(false);
    }

}