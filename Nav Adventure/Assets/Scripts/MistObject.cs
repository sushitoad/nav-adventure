using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistObject : MonoBehaviour
{
    //this eventually should unsubscribe the event at a proper time?
    [SerializeField] bool seasonFlip = false;

    private void Start() 
    {
        FindObjectOfType<MistController>().mistSeasonEvent += OnSeasonChange;
    }

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
