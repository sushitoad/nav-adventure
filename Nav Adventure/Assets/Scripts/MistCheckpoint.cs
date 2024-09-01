using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCheckpoint : MonoBehaviour
{
    MistController mistController;
    public float fadeSpeed = 2f;
    public Transform mistRune;
    public ParticleSystem fogWall;
    public float emissionRate = 10f;

    private void Start()
    {
        mistController = FindObjectOfType<MistController>();
        var emission = fogWall.emission;
        emission.rateOverTime = emissionRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mistController.mistRune = mistRune;
            MistCheckpoint[] otherCheckpoints = FindObjectsOfType<MistCheckpoint>();
            foreach(MistCheckpoint checkpoint in otherCheckpoints)
            {
                var em = checkpoint.fogWall.emission;
                em.rateOverTime = emissionRate;
            }
            var emission = fogWall.emission;
            emission.rateOverTime = 0f;
        }
    }
}
