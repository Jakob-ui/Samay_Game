using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaterLever : MonoBehaviour
{
    [Header("Lever Variables")]
    public static bool waterState;
    private bool leverState;
    private List<GameObject> waterfountains;
    private bool flag = false;
    [SerializeField] private TextMeshProUGUI leverText;
    [SerializeField] private Animator animator;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event leveroff;
    [SerializeField] AK.Wwise.Event leveron;


    void Start()
    {
        waterfountains = new List<GameObject>();
        GameObject[] foundFountains = GameObject.FindGameObjectsWithTag("Fountain");
        waterfountains.AddRange(foundFountains);
        DeactivateAll();
        leverText.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !flag && leverState || Input.GetKeyDown("joystick button 2") && !flag && leverState)
        {
            flag = !flag;
            ActivateAll();
            animator.SetBool("LeverState", true);
            leveroff.Post(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.F) && flag && leverState || Input.GetKeyDown("joystick button 2") && flag && leverState)
        {
            flag = !flag;
            DeactivateAll();
            animator.SetBool("LeverState", false);
            leveron.Post(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverState = true;
            leverText.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverState = false;
            leverText.enabled = false;
        }
    }

    void DeactivateAll()
    {
        foreach (GameObject obj in waterfountains)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    void ActivateAll()
    {
        foreach (GameObject obj in waterfountains)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
