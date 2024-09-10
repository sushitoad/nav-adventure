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
    bool hasSwapped;

    private void Start() 
    {
        mistController = FindObjectOfType<MistController>();
        mistController.mistSeasonEvent += ResetForNewSeason;
        ResetForNewSeason();
    }

    private void Update() 
    {
        float percentMisty = mistController.mistCounter / mistController.mistTime;
        //needs to also check if this is in the view of the player, and only switch if it isn't
        if(percentMisty >= swapTimePercent && !hasSwapped)
        {
            zoneIndex++;
            Swap(zoneIndex);
            hasSwapped = true;
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
        hasSwapped = false;
    }
}
