using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCam : MonoBehaviour
{
    PlayerController player;
    float zDifference;
    private void Start()
    {
        player = (PlayerController)FindObjectOfType(typeof(PlayerController));
        zDifference = transform.position.z;    
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + zDifference);
    }
}
