using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class TimeStopControll : MonoBehaviour
{
    [Header("Timestopmode")]
    private List<Rigidbody> freezingItemsRBs;
    private List<ParticleSystem> freezingParticles;
    [SerializeField] public Material timeeffect;


    [Header("Timestop Check")]
    public static bool activated = false;


    [Header("Time Bar")]
    private float maxValue = 50f;
    private float currentValue;
    public TimeBar timeBar;
    private bool reduce;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event timestop;
    [SerializeField] AK.Wwise.Event timeBareffect;
    [SerializeField] AK.Wwise.RTPC timeBarPitch;



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
        timeBarPitch.SetGlobalValue(50);
        timeBareffect.Stop(gameObject);
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
        if (currentValue == 50 && !activated)
        {
            timeBareffect.Stop(gameObject);
        }

        timeBarPitch.SetGlobalValue(currentValue);
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
        if (currentValue < 50 && reduce)
        {
            timeBareffect.Stop(gameObject);
            timeBareffect.Post(gameObject);
            reduce = false;
        }
        currentValue -= damage;
        timeBar.SetStrengh(currentValue);
    }

    void RecoverTimeBar(float recover)
    {
        if (currentValue >= 0 && !reduce)
        {
            timeBareffect.Stop(gameObject);
            timeBareffect.Post(gameObject);
            reduce = true;
        }
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