using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    Vector3 currentCamPos, destinationCamPos;
    float camTransitionCounter = 0f;
    bool adjacentTransition = false;

    public Camera cam;

    public float moveSpeed, camTransitionTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentCamPos = cam.transform.position;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 && movement.y != 0)
        {
            movement = movement.normalized;
        }
        if(adjacentTransition)
        {
            movement = new Vector2(0, 0);
            camTransitionCounter += Time.deltaTime / camTransitionTime;
            cam.transform.position = Vector3.Lerp(currentCamPos, destinationCamPos, camTransitionCounter);
            if(camTransitionCounter >= 1f)
            {
                adjacentTransition = false;
                camTransitionCounter = 0f;
                cam.transform.position = destinationCamPos;
                currentCamPos = cam.transform.position;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    //this should be an event where the camera behavior is separate but both trigger
    public void MoveToNewScreen(Transform screen, Transform entrance, bool misty)
    {
        currentCamPos = cam.transform.position;
        destinationCamPos = new Vector3(screen.position.x, screen.position.y, cam.transform.position.z);
        transform.position = new Vector3(entrance.position.x, entrance.position.y, transform.position.z);
        if(misty)
        {
            Debug.Log("The mists carry you somewhere else...");
            cam.transform.position = new Vector3(screen.position.x, screen.position.y, cam.transform.position.z);
        } 
        else if(!misty)
        {
            Debug.Log("You move to the glade nearby.");
            adjacentTransition = true;
        }       
    }

}
