using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;

    public Camera cam;

    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 && movement.y != 0)
        {
            movement = movement.normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void MoveToNewScreen(Transform screen, Transform entrance)
    {
        transform.position = new Vector3(entrance.position.x, entrance.position.y, transform.position.z);
        cam.transform.position = new Vector3(screen.position.x, screen.position.y, cam.transform.position.z);
    }

}
