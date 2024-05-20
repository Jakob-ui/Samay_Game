using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 playerStartPosition;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned!");
            return;
        }
        playerStartPosition = player.transform.position;
    }

    void Update()
    {
        if (player == null) return;

        if (player.transform.position.y <= 7)
        {
            player.transform.position = playerStartPosition;
            Debug.Log("Player is dead due to falling.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pendulum"))
        {
            Debug.Log("Player is dead due to collision with Pendulum.");
            player.transform.position = playerStartPosition;
        }
    }
}