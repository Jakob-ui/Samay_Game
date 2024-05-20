using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopControll : MonoBehaviour
{
    [Header("Sphere Parameters")]
    [SerializeField] private float targetScale = 40.0f;
    [SerializeField] private float scaleSpeed = 0.20f;
    [SerializeField] private MeshRenderer sphereRenderer;


    [Header("Timestopmode")]
    [SerializeField] private bool sphereMode;
    private List<Rigidbody> freezingItemsRBs;
    //[SerializeField] private Material timeeffect;


    [Header("Timestop Check")]
    private bool isScaling = false;
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
                Debug.LogWarning("Rigidbody component is missing on " + item.name);
                continue;
            }
            freezingItemsRBs.Add(rb);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (sphereMode && !isScaling)
            {
                StartCoroutine(ScaleUp());
            }
            else if (!sphereMode)
            {
                Timestop();
            }
            activated = !activated;
        }
        ControllTimeBar();
    }

    private IEnumerator ScaleUp()
    {
        if (!activated)
        {
            sphereRenderer.enabled = false;
        }
        else
        {
            sphereRenderer.enabled = true;
        }
        isScaling = true;

        while (transform.localScale.x < targetScale)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        isScaling = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FreezingItem")
        {
            Rigidbody sphereRB = other.gameObject.GetComponent<Rigidbody>();
            if (sphereRB != null)
            {
                if (!activated)
                {
                    sphereRB.constraints = RigidbodyConstraints.FreezeAll;
                }
                else
                {
                    sphereRB.constraints = RigidbodyConstraints.None;
                    sphereRB.constraints = RigidbodyConstraints.FreezeRotation;
                }
            }
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
        if (activated == false)
        {
            //timeeffect.SetFloat("_Fullscreenintesity", 0.1f);
            ReduceTimeBar(0.05f);
        }
        else
        {
            RecoverTimeBar(0.5f);
            //timeeffect.SetFloat("_Fullscreenintesity", 0f);
        }

        if (currentValue <= 0)
        {
            activated = true;
            StartCoroutine(ScaleUp());
        }
    }

}