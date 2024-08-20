using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnderLogDetector : MonoBehaviour
{
    SpriteRenderer playerSprite;

    public bool exit = false;
    public int logSortingOrder = -6;
    public GameObject[] overBumpers, underBumpers;
    MistController mistController;

    void Start()
    {
        Object player = FindObjectOfType<PlayerController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        mistController = FindObjectOfType<MistController>();
        mistController.mistSeasonEvent += ExitLog;
        ExitLog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (exit) 
            { ExitLog(); }
            else { EntranceLog(); }
        }
    }

    void EntranceLog()
    {
        playerSprite.sortingOrder = logSortingOrder;
        //foreach bumper in underbumper array, set active
        foreach (GameObject bumper in underBumpers)
        {
            bumper.gameObject.SetActive(true);
        }
        foreach (GameObject bumper in overBumpers)
        {
            bumper.gameObject.SetActive(false);
        }
    }

    void ExitLog()
    {
        playerSprite.sortingOrder = 0;
        foreach (GameObject bumper in underBumpers)
        {
            bumper.gameObject.SetActive(false);
        }
        foreach (GameObject bumper in overBumpers)
        {
            bumper.gameObject.SetActive(true);
        }
    }
}
