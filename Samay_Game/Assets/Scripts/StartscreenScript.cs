using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartscreenScript : MonoBehaviour
{
    [SerializeField] private Button start;
    [SerializeField] private Button controlls;
    [SerializeField] private Button quit;
    [SerializeField] private Button back;
    public SceneSwitch scene;
    public GameObject controllCanvas;
    public static bool isPaused = false;

    void Start()
    {
        start.onClick.AddListener(StartGame);
        controlls.onClick.AddListener(Controlls);
        quit.onClick.AddListener(QuitGame);
        back.onClick.AddListener(Back);
        controllCanvas.SetActive(false);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Debug.Log("Starting Game...");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        scene.LoadSceneByName("Tutorial");
    }

    void Controlls()
    {
        controllCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Back()
    {
        controllCanvas.SetActive(false);
    }

}