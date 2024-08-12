using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistObject : MonoBehaviour
{
    //this eventually should subscribe a function to an event
    [SerializeField] bool seasonFlip = false;

    public void OnSeasonChange()
    {
        seasonFlip = !seasonFlip;
        if(seasonFlip)
        {
            this.gameObject.SetActive(false);
        }
        else { this.gameObject.SetActive(true); }
    }

}
