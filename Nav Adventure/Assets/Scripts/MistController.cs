using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MistController : MonoBehaviour
{
    public event Action mistSeasonEvent;
    public int seasonMin, seasonMax;
    private int mistSeason;
    public int MistSeason
        { 
            get {return mistSeason;} 
            private set
            {
                if(value >= seasonMin && value <= seasonMax)
                {
                    mistSeason = value;
                }
            } 
        }
    
    public Transform mistRune;
    public float mistTime;
    public float playerIdleMistMod, dewLightMistMod;
    public Slider mistBar;
    float mistBarWidth;
    float mistCountdown;
    PlayerController player;

    private void Start()
    {
        mistCountdown = 0f;
        player = FindObjectOfType<PlayerController>();
        MistSeason = seasonMin;
        mistBar.value = 0f;
    }

    private void Update()
    {
        float countMods = 1f;
        if(Mathf.Abs(player.movement.x) <= 0.05f && Mathf.Abs(player.movement.y) <= 0.05f)
        {
            countMods -= playerIdleMistMod;
        }
        //if under dewlight, subract mod from countMods
        mistCountdown += Time.deltaTime * countMods;

        mistBar.value = mistCountdown / mistTime;
        if (mistCountdown >= mistTime)
        {
            WarpToMistRune();
            SeasonChange();
        }
    }

    void WarpToMistRune()
    {
        player.transform.position = mistRune.position;
    }

    void SeasonChange()
    {
            mistCountdown = 0f;
            if(MistSeason < seasonMax)
            {
                MistSeason++;
            } else
            {
                MistSeason = seasonMin;
            }
            Debug.Log(MistSeason.ToString());
            if(mistSeasonEvent != null)
            {
                mistSeasonEvent();
            }
    }
}
