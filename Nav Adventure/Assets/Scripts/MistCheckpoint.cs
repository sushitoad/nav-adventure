using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCheckpoint : MonoBehaviour
{
    MistController mistController;

    public Transform mistRune;
    public ParticleSystem fogWall;
    [HideInInspector] public bool activated = false;
    float startEmissionRate, currentEmissionRate;
    ParticleSystem.EmissionModule emission;

    private void Start()
    {
        mistController = FindObjectOfType<MistController>();
        activated = false;
        emission = fogWall.GetComponent<ParticleSystem.EmissionModule>();
        startEmissionRate = emission.rateOverTime.constant;
        print(startEmissionRate);
    }

    public void Update()
    {
        if(activated)
        {
            //lower emission
        } else if(!activated)
        {
            //raise emission
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mistController.mistRune = mistRune;
            MistCheckpoint[] otherCheckpoints = FindObjectsOfType<MistCheckpoint>();
            foreach(MistCheckpoint checkpoint in otherCheckpoints)
            {
                checkpoint.activated = false;
            }
            //this needs to flip a bool that allows me to gradually lower ParticleSystem.emission's rate over time to zero
            //then would be good to gradually raise the emission rate of the other fogwalls
            activated = true;
        }
    }
}
