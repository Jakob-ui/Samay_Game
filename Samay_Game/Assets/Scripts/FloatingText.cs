using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform obj;
    Transform worldSpaceCanvas;
    [SerializeField] private Canvas canvas;
    public Vector3 offset;

    void Start()
    {
        mainCam = Camera.main.transform;
        obj = transform.parent;
        worldSpaceCanvas = canvas.transform;

        transform.SetParent(worldSpaceCanvas);
    }


    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = obj.position + offset;
    }
}
