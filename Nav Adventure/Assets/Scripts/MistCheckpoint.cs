using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCheckpoint : MonoBehaviour
{
    MistController mistController;

    public Transform mistRune;
    public GameObject fogWall;

    private void Start()
    {
        mistController = FindObjectOfType<MistController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mistController.mistRune = mistRune;
            MistCheckpoint[] otherCheckpoints = FindObjectsOfType<MistCheckpoint>();
            foreach(MistCheckpoint checkpoint in otherCheckpoints)
            {
                checkpoint.fogWall.SetActive(true);
            }
            //this needs to flip a bool that allows me to gradually lower ParticleSystem.emission's rate over time to zero
            //then would be good to gradually raise the emission rate of the other fogwalls
            fogWall.SetActive(false);
        }
    }
}
