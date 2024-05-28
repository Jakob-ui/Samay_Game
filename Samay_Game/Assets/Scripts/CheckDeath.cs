using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    private Vector3 playerStartPosition;

    private bool isDead = false;

    void Start()
    {
        playerStartPosition = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        if (transform.position.y <= 10)
        {
            isDead = true;
        }

        if (isDead)
        {
            player.enabled = false;
            transform.position = playerStartPosition;
            player.enabled = true;

            isDead = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isDead = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pendulum"))
        {
            isDead = true;
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            isDead = true;
        }
        if (other.gameObject.CompareTag("Death"))
        {
            isDead = true;
        }
    }
}