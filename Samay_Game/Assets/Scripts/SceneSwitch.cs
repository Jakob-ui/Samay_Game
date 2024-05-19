using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneSwitch : MonoBehaviour
{
    bool startScreen = true;
    bool gameScreen = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (startScreen && Input.GetKeyDown("Spacebar"))
        {
            startScreen = false;
            gameScreen = true;

            //SceneSwitch.LoadScene()
        }
    }
}
