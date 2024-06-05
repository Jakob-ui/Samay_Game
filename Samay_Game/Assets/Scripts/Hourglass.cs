using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    private float rotationAngle = -90f;
    private bool canRotate = false;
    private float rotationDuration = 1f;
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && canRotate && !isRotating)
        {
            StartCoroutine(RotateSmoothly(Vector3.right, rotationAngle, rotationDuration));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotate = false;
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
        Debug.Log("Hourglass rotated EULER! " + gameObject.name + " " + transform.localRotation.eulerAngles.ToString());
    }
}
