using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private FadeInOut fade;
    public SceneSwitch scene;
    public bool SceneSwitch;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        scene.LoadSceneByName("EndScreen");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("sceneswitch");
        if (other.gameObject.CompareTag("Player") && SceneSwitch)
        {
            StartCoroutine(ChangeScene());
        }
    }
}