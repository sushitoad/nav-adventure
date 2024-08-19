using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistObject : MonoBehaviour
{
    public enum MistBehavior
    {
        Timer, Season
    }
    public MistBehavior mistBehavior;

    //this eventually should unsubscribe the event at a proper time?
    [SerializeField] bool hasDisappeared = false;
    [SerializeField] float timerChangePercent = 0.5f;
    MistController mistController;

    private void Start() 
    {
        mistController = FindObjectOfType<MistController>();
        mistController.mistSeasonEvent += ToggleDisappear;
        if (hasDisappeared)
        {
            this.gameObject.SetActive(false);
        }
        else { this.gameObject.SetActive(true); }
    }

    private void Update()
    {
        if(mistBehavior == MistBehavior.Timer) 
        {
            float cyclePercent = mistController.mistCountdown / mistController.mistTime;
            if (cyclePercent >= timerChangePercent)
            {
                ToggleDisappear();
            }
        }
    }

    public void ToggleDisappear()
    {
        hasDisappeared = !hasDisappeared;
        if(hasDisappeared)
        {
            this.gameObject.SetActive(false);
        }
        else { this.gameObject.SetActive(true); }
    }

}
