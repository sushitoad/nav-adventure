using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistCheckpoint : MonoBehaviour
{
    MistTimer mistController;

    public Transform mistRune;

    private void Start()
    {
        mistController = FindObjectOfType<MistTimer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mistController.mistRune = mistRune;
        }
    }
}
