using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dewlight : MonoBehaviour
{
    public Sprite close, transition, open;
    public float transitionSpeed = 0.2f;
    MistController mistController;
    SpriteRenderer sprite;
    //Animator animator;

    private void Start() 
    {
        mistController = FindObjectOfType<MistController>();
        sprite = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            mistController.isUnderDewlight = true;
            //animator.Play("Open_Dewlight");
            StopAllCoroutines();
            StartCoroutine(AnimateTransition());
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            mistController.isUnderDewlight = false;
            //animator.Play("Close_Dewlight");
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
        } else 
        {
            sprite.sprite = close;
        }
    }
}
