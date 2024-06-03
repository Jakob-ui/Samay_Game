using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopControll : MonoBehaviour
{
    [Header("Timestopmode")]
    private List<Rigidbody> freezingItemsRBs;
    [SerializeField] public Material timeeffect;


    [Header("Timestop Check")]
    public static bool activated = true;


    [Header("Time Bar")]
    private float maxValue = 40f;
    private float currentValue;
    public TimeBar timeBar;


    void Start()
    {
        currentValue = maxValue;
        timeBar.SetMaxStrengh(maxValue);

        freezingItemsRBs = new List<Rigidbody>();
        GameObject[] freezingItems = GameObject.FindGameObjectsWithTag("FreezingItem");
        foreach (GameObject item in freezingItems)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogWarning("Rigidbody for Freeze effect is missing on " + item.name);
                continue;
            }
            freezingItemsRBs.Add(rb);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !PauseMenu.isPaused || Input.GetKeyDown("joystick button 1") && !PauseMenu.isPaused)
        {
            Timestop();
            activated = !activated;
        }
        ControllTimeBar();
    }

    void Timestop()
    {
        foreach (Rigidbody rb in freezingItemsRBs)
        {
            if (activated)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    void ReduceTimeBar(float damage)
    {
        currentValue -= damage;
        timeBar.SetStrengh(currentValue);
    }

    void RecoverTimeBar(float recover)
    {
        currentValue += recover;
        currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
        timeBar.SetStrengh(currentValue);
    }

    void ControllTimeBar()
    {
        if (!activated)
        {
            timeeffect.SetFloat("_FullScreenIntensity", 0.1f);
            ReduceTimeBar(0.04f);
        }
        else
        {
            RecoverTimeBar(0.025f);
            timeeffect.SetFloat("_FullScreenIntensity", 0f);
        }

        if (currentValue <= 0)
        {
            activated = true;
        }
    }

}