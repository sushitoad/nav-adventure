using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MistTimer : MonoBehaviour
{
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
        }
    }

    void WarpToMistRune()
    {
        player.transform.position = mistRune.position;
    }
}
