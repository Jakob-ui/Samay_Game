using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private GameObject DeathPlane;
    private Vector3 playerStartPosition;
    private float deathcoords;

    private bool isDead = false;

    void Start()
    {
        playerStartPosition = transform.position;
        if (DeathPlane != null)
        {
            deathcoords = DeathPlane.transform.position.y + 1;
        }
    }

    void Update()
    {
        if (player == null) return;



        if (transform.position.y <= deathcoords)
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
        if (other.gameObject.CompareTag("Death"))
        {
            isDead = true;
        }
    }
}