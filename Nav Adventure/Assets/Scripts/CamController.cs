using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Vector3 currentCamPos, destinationCamPos;
    float camTransitionCounter = 0f;
    bool adjacentTransition = false;

    public Camera cam;
    public float camTransitionTime;

    private void Start() 
    {
        cam = GetComponent<Camera>();
    }

    private void Update() 
    {
        if(adjacentTransition)
        {
            //movement = new Vector2(0, 0);
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
    //move to new screen
    //currentCamPos = cam.transform.position;
    //destinationCamPos = new Vector3(screen.position.x, screen.position.y, cam.transform.position.z);
    /*if(misty)
        {
            Debug.Log("The mists carry you somewhere else...");
            cam.transform.position = new Vector3(screen.position.x, screen.position.y, cam.transform.position.z);
        } 
        else if(!misty)
        {
            Debug.Log("You move to the glade nearby.");
            adjacentTransition = true;
        }  */ 

}
