using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    PlayerController player;
    bool isJumping;
    float jumpCounter;
    Vector3 travelPoint, jumpStart;
    public float jumpLength;
    public float jumpDistance = 1f;
    public BoxCollider2D lower;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (isJumping)
        {
            player.movement = Vector2.zero;
            player.transform.position = Vector3.Lerp(jumpStart, travelPoint, jumpCounter);
            jumpCounter += Time.deltaTime / jumpLength;
            if (jumpCounter >= 1f) { isJumping = false; lower.enabled = true; }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            lower.enabled = false;
            Vector2 travel = player.movement * jumpDistance;
            travelPoint = new Vector3(player.transform.position.x + travel.x, player.transform.position.y + travel.y, 0f);
            jumpStart = player.transform.position;
            isJumping = true;
            jumpCounter = 0;
        }
    }
}
