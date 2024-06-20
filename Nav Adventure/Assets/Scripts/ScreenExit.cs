using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenExit : MonoBehaviour
{
    PlayerController player;
    public Transform incomingScreen, entrancePoint;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.MoveToNewScreen(incomingScreen, entrancePoint);
        }    
    }
}
