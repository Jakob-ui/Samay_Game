using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("Pendulum")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float limit = 75f;
    [SerializeField] private float offset = 0f;

    private float rotationZ = 0f;
    private float rotationFactor = 1;

    void Start()
    {
        rotationZ = offset;
    }

    void Update()
    {
        if (!TimeStopControll.activated)
        {
            if (rotationZ > limit)
                rotationFactor = -1;
            else if (rotationZ < 0)
                rotationFactor = 1;

            rotationZ += rotationFactor * speed * Time.deltaTime;

            transform.localRotation = Quaternion.Euler(0f, 0f, rotationZ - (limit / 2));
        }
    }
}