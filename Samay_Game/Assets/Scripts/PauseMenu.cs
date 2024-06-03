using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resume;
    [SerializeField] private Button quit;
    [SerializeField] private Button menu;
    public SceneSwitch scene;
    public GameObject pauseMenuPanel;
    private bool isPaused = false;

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

        Debug.Log("Resuming game...");
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void PauseGame()
    {
        Debug.Log("Pausing game...");
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
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
    public void Menu()
    {
        Debug.Log("Resuming game...");
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        scene.LoadSceneByName("Startscreen");
    }
}
