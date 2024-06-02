using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutLevelExitTrigger : MonoBehaviour
{
    public SceneSwitch scene;
    public bool SceneSwitch;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("sceneswitch");
        if (other.gameObject.CompareTag("Player") && SceneSwitch)
        {
            scene.LoadSceneByName("LEVEL_2");
        }
    }
}
