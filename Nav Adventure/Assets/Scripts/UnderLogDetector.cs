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

    void Start()
    {
        Object player = FindObjectOfType<PlayerController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        EnterExitLog(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EnterExitLog(exit);
        }
    }

    void EnterExitLog(bool exiting)
    {
        if (!exiting)
        {
            playerSprite.sortingOrder = logSortingOrder;
            //foreach bumper in underbumper array, set active
            foreach (GameObject bumper in underBumpers)
            {
                bumper.gameObject.SetActive(true);
            }
            foreach(GameObject bumper in overBumpers)
            {
                bumper.gameObject.SetActive(false);
            }
        }
        if (exiting)
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
}
