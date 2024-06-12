using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private MeshRenderer ring;
    [Header("Timebar")]
    [SerializeField] private TimeBar timeBar;

    private Color emissionStartColor;
    private bool isHighlighted = false;

    private void Start()
    {
        emissionStartColor = highlightMaterial.GetColor("_EmissionColor");
    }

    private void Update()
    {
        if (TimeStopControll.activated)
        {
            if (!isHighlighted)
            {
                isHighlighted = true;
                ring.sharedMaterial = highlightMaterial;
            }
            highlightMaterial.SetColor("_EmissionColor", emissionStartColor * (timeBar.GetStrength() / 50f));
        }
        else
        {
            if (isHighlighted)
            {
                isHighlighted = false;
                ring.sharedMaterial = baseMaterial;
            }
        }
    }

    private void OnApplicationQuit()
    {
        highlightMaterial.SetColor("_EmissionColor", emissionStartColor);
    }
}
