using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSwap : MonoBehaviour
{
    //try and make a struct that bundles the game object and float variables together
    public GameObject[] zones;
    public float swapTimePercent;

    MistController mistController;
    int zoneIndex;

    private void Start() 
    {
        mistController = FindObjectOfType<MistController>();
        mistController.mistSeasonEvent += ResetForNewSeason;
        zoneIndex = 0;
        Swap(zoneIndex);
    }

    private void Update() 
    {
        float percentMisty = mistController.mistCounter / mistController.mistTime;
        //right now this is broken because it keeps doing this over and over, needs a check to stop it
        if(percentMisty >= swapTimePercent)
        {
            zoneIndex++;
            Swap(zoneIndex);
        }
    }

    public void Swap(int zoneToActivate)
    {
        foreach (GameObject zone in zones)
        {
            zone.SetActive(false);
        }
        zones[zoneToActivate].SetActive(true);
    }

    public void ResetForNewSeason()
    {
        Swap(0);
        zoneIndex = 0;
    }
}
