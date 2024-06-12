using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class Hourglass : MonoBehaviour
{

    private float rotationAngle = -90f;
    private bool canRotate = false;
    private float rotationDuration = 1f;
    private bool isRotating = false;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI leverText;



    [Header("Audio")]
    [SerializeField] AK.Wwise.Event hourglass;

    void Start()
    {
        leverText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canRotate && !isRotating || Input.GetKeyDown("joystick button 2") && canRotate && !isRotating)
        {
            StartCoroutine(RotateSmoothly(Vector3.right, rotationAngle, rotationDuration));
            hourglass.Post(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotate = true;
            leverText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotate = false;
            leverText.enabled = false;
        }
    }

    private IEnumerator RotateSmoothly(Vector3 axis, float angle, float duration)
    {
        isRotating = true;

        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = transform.localRotation * Quaternion.Euler(axis * angle);
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
        isRotating = false;
    }
}
