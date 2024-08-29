using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCheckpoint : MonoBehaviour
{
    MistController mistController;
    public float fadeSpeed = 2f;
    public Transform mistRune;
    public ParticleSystem fogWall;
    [HideInInspector] public bool activated = false;
    float startEmissionRate, currentEmissionRate;

    private void Start()
    {
        mistController = FindObjectOfType<MistController>();
        activated = false;
        startEmissionRate = fogWall.emission.rateOverTime.constant;
    }

    public void Update()
    {
        currentEmissionRate = fogWall.emission.rateOverTime;
        if(activated && currentEmissionRate > 0f)
        {
            //lower emission
            float reduction = Time.deltaTime * fadeSpeed;
            fogWall.emission.rateOverTime -= reduction;
            if(currentEmissionRate < 0f)
            {
                fogWall.emission.rateOverTime = 0f;
            }
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
