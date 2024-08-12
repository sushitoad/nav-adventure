using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MistController : MonoBehaviour
{
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
    public TMP_Text timerText;
    float mistCountdown;
    PlayerController player;

    private void Start()
    {
        mistCountdown = mistTime;
        player = FindObjectOfType<PlayerController>();
        timerText.text = mistTime.ToString();
        MistSeason = seasonMin;
    }

    private void Update()
    {
        mistCountdown -= Time.deltaTime;
        int textNum = Mathf.CeilToInt(mistCountdown);
        timerText.text = textNum.ToString();
        if (mistCountdown <= 0f)
        {
            WarpToMistRune();
            mistCountdown = mistTime;
            if(MistSeason < seasonMax)
            {
                MistSeason++;
            } else
            {
                MistSeason = seasonMin;
            }
            Debug.Log(MistSeason.ToString());
        }
    }

    void WarpToMistRune()
    {
        player.transform.position = mistRune.position;
    }
}
