using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    private float rotationSpeed = 20.0f;
    [SerializeField] private float startangle;
    [SerializeField] private float currentangle;
    [SerializeField] private float destinationAngle;
    private float angle = 90f;
    private bool turnLeft = false;
    private bool turnRight = false;
    void Start()
    {
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && !turnRight || Input.GetKeyDown("joystick button 5") && turnRight)
        {
            turnRight = true;
            startangle = transform.rotation.eulerAngles.x;
            destinationAngle = startangle + angle;
        }
        if (Input.GetKeyDown(KeyCode.R) && !turnLeft || Input.GetKeyDown("joystick button 4") && turnLeft)
        {
            turnLeft = true;
            startangle = transform.localEulerAngles.x;
            destinationAngle = startangle - angle;
        }
        TurnLeft();
        TurnRight();
    }

    private void TurnLeft()
    {
        currentangle = transform.localEulerAngles.x;
        if (turnLeft)
        {
            float angleDelta = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.left * angleDelta, Space.Self);
            if (destinationAngle >= currentangle)
            {
                turnLeft = false;
            }
        }

    }

    private void TurnRight()
    {
        currentangle = transform.localEulerAngles.x;
        if (turnRight)
        {
            float angleDelta = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right * angleDelta, Space.Self);
            if (destinationAngle <= currentangle)
            {
                turnRight = false;
            }
        }
    }


}
