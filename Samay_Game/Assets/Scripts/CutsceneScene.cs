using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScene : MonoBehaviour
{
    public float changeTime;
    

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneSwitch sceneSwitch = new SceneSwitch();
            sceneSwitch.LoadSceneByName("Tutorial");
        }

    }
}
