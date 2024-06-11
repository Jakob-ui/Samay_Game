using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Controlls")]
    [SerializeField] private Button resume;
    [SerializeField] private Button quit;
    [SerializeField] private Button menu;
    public SceneSwitch scene;
    public GameObject pauseMenuPanel;
    public static bool isPaused = false;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event click;

    void Start()
    {
        resume.onClick.AddListener(ResumeGame);
        quit.onClick.AddListener(QuitGame);
        menu.onClick.AddListener(Menu);

        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        AkSoundEngine.WakeupFromSuspend();
        click.Post(gameObject);
        Debug.Log("Resuming game...");
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void PauseGame()
    {
        AkSoundEngine.Suspend();
        Debug.Log("Pausing game...");
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
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
    public void Menu()
    {
        AkSoundEngine.WakeupFromSuspend();
        click.Post(gameObject);
        Debug.Log("Resuming game...");
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        scene.LoadSceneByName("Startscreen");
    }
}
