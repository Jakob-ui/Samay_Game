using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartscreenScript : MonoBehaviour
{
    public SceneSwitch scene;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            scene.LoadSceneByName("TUT_NEUa");
        }
    }
}