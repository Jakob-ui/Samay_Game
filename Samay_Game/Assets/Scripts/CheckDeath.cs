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
        if (player == null)
        {
            Debug.LogError("Player CharacterController is not assigned!");
            return;
        }
        playerStartPosition = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        if (transform.position.y <= 6)
        {
            isDead = true;
            Debug.Log("Player is dead due to falling.");
        }

        if (isDead)
        {
            player.enabled = false;
            transform.position = playerStartPosition;
            player.enabled = true;

            isDead = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pendulum"))
        {
            isDead = true;
            Debug.Log("Player is dead due to collision with Pendulum.");
        }
    }
}