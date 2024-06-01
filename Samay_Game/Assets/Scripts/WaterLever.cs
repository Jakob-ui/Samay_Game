using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaterLever : MonoBehaviour
{
    public static bool waterState;
    private bool leverState;
    private List<GameObject> waterfountains;
    private bool flag = false;
    [SerializeField] private TextMeshProUGUI leverText;
    [SerializeField] private Animator animator;



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
        if (Input.GetKeyDown(KeyCode.F) && !flag && leverState)
        {
            flag = !flag;
            ActivateAll();
            Debug.Log("wasser marsch");
            animator.SetBool("LeverState", true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && flag && leverState)
        {
            flag = !flag;
            DeactivateAll();
            Debug.Log("stop wasser");
            animator.SetBool("LeverState", false);
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
