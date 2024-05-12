using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{

    [SerializeField] private GameObject player;
    Vector3 PlayerPosition;
    void Start()
    {
        PlayerPosition = player.transform.position;
    }

    void Update()
    {
        if(player.transform.position.y <= -1.5){
            player.transform.position = PlayerPosition;
        }
    }
}
