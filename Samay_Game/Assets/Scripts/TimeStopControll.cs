using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopControll : MonoBehaviour
{
    [Header("Timestopmode")]
    private List<Rigidbody> freezingItemsRBs;
    private List<ParticleSystem> freezingParticles;
    [SerializeField] public Material timeeffect;


    [Header("Timestop Check")]
    public static bool activated = false;


    [Header("Time Bar")]
    private float maxValue = 40f;
    private float currentValue;
    public TimeBar timeBar;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event timestop;


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

        freezingParticles = new List<ParticleSystem>();
        GameObject[] freezingParticlesGameObjects = GameObject.FindGameObjectsWithTag("FreezingParticles");
        foreach (GameObject item in freezingParticlesGameObjects)
        {
            ParticleSystem[] ps = item.GetComponentsInChildren<ParticleSystem>();
            if (ps == null)
            {
                Debug.LogWarning("ParticleSystems for Freeze effect are missing on " + item.name);
                continue;
            }
            freezingParticles.AddRange(ps);
        }
    }

    void Update()
    {
        bool flag = false;
        if (Input.GetKeyDown(KeyCode.Q) && !PauseMenu.isPaused || Input.GetKeyDown("joystick button 1") && !PauseMenu.isPaused)
        {
            activated = !activated;
            flag = true;
        }
        Timestop();
        ControllTimeBar();

        if (activated && flag)
        {
            timestop.Post(gameObject);
            flag = false;
        }
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
        foreach (ParticleSystem ps in freezingParticles)
        {
            if (activated)
            {
                ps.Pause();
            }
            else if (ps.isPaused)
            {
                ps.Play();
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
        if (activated)
        {
            timeeffect.SetFloat("_FullScreenIntensity", 0.1f);
            ReduceTimeBar(Time.deltaTime * 10);
        }
        else
        {
            RecoverTimeBar(Time.deltaTime * 5);
            timeeffect.SetFloat("_FullScreenIntensity", 0f);
        }

        if (currentValue <= 0)
        {
            activated = false;
        }
    }

}