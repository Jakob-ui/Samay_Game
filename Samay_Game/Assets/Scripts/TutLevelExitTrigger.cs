using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutLevelExitTrigger : MonoBehaviour
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
        scene.LoadSceneByName("LEVEL_2");
    }
    void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.StopAll();
        if (other.gameObject.CompareTag("Player") && SceneSwitch)
        {
            StartCoroutine(ChangeScene());
        }
    }
}
