using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    PlayerController player;
    public float jumpDistance = 1f;
    public BoxCollider2D lower;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            Debug.Log("Jump off the ledge!");
            lower.enabled = false;
            float xJump = player.transform.position.x;
            float yJump = player.transform.position.y;
            //this does not work yet, need to not multiply position by jump distance
            if(player.movement.x >= 1f) {xJump = xJump * jumpDistance;}
            if(player.movement.y >= 1f) {yJump = yJump * jumpDistance;}
            Vector3 jumpDirection = new Vector3(xJump, yJump, 0f);
            player.transform.position = jumpDirection;
            lower.enabled = true;
        }
    }
}
