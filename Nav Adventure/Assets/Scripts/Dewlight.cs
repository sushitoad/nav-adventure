using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dewlight : MonoBehaviour
{
    public Sprite close, transition, open;
    public float transitionSpeed = 0.2f;
    Light2D glow;
    float startIntensity = 2f;
    MistController mistController;
    SpriteRenderer sprite;

    private void Start() 
    {
        mistController = FindObjectOfType<MistController>();
        sprite = GetComponent<SpriteRenderer>();
        glow = GetComponentInChildren<Light2D>();
        startIntensity = glow.intensity;
        glow.intensity = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            mistController.isUnderDewlight = true;
            StopAllCoroutines();
            StartCoroutine(AnimateTransition());
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            mistController.isUnderDewlight = false;
            StopAllCoroutines();
            StartCoroutine(AnimateTransition());
        }
    }

    IEnumerator AnimateTransition()
    {
        sprite.sprite = transition;
        yield return new WaitForSeconds(transitionSpeed);
        if(mistController.isUnderDewlight == true)
        {
            sprite.sprite = open;
            glow.intensity = startIntensity;
        } else 
        {
            sprite.sprite = close;
            glow.intensity = 0f;
        }
    }
}
