using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TUTTexteActivator : MonoBehaviour
{
    [SerializeField] private GameObject TextPanel;
    [SerializeField] private TMP_Text tutTextpanel;
    [SerializeField] private string tutText;
    [SerializeField] private float fadeDuration = 1.0f;
    private Material textMaterial;
    [SerializeField] private Material planeMaterial;

    void Start()
    {
        TextPanel.SetActive(false);
        tutTextpanel.text = tutText;
        textMaterial = tutTextpanel.fontMaterial;
        SetMaterialAlpha(0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextPanel.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            float alphaplane = Mathf.Clamp(elapsedTime / fadeDuration, 0, 0.5f);
            SetMaterialAlpha(alpha);
            SetMaterialAlphaPlane(alphaplane);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
            float alphaplane = 0.5f - Mathf.Clamp(elapsedTime / fadeDuration, 0, 0.5f);
            SetMaterialAlpha(alpha);
            SetMaterialAlphaPlane(alphaplane);
            yield return null;
        }
        TextPanel.SetActive(false);
    }

    private void SetMaterialAlpha(float alpha)
    {
        Color color = textMaterial.GetColor("_FaceColor");
        color.a = alpha;
        textMaterial.SetColor("_FaceColor", color);
    }
    private void SetMaterialAlphaPlane(float alpha)
    {
        Color col = planeMaterial.color;
        col.a = alpha;
        planeMaterial.color = col;
    }
}
