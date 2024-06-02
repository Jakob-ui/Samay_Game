using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartscreenScript : MonoBehaviour
{
    public SceneSwitch scene;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scene.LoadSceneByName("TUT_NEUa");
        }
    }
}