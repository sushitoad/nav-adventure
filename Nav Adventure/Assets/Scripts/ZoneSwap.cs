using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSwap : MonoBehaviour
{
    //try and make a struct that bundles the game object and float variables together
    public class Zone 
    {
        public GameObject elements;
        public float swapTimePercent;
    }
    //how do I get this to show in inspector?
    public Zone[] zones;

    MistController mistController;
    int zoneIndex;
    float currentSwapPercent;

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
        if(percentMisty >= currentSwapPercent)
        {
            zoneIndex++;
            Swap(zoneIndex);
        }
    }

    public void Swap(int zoneToActivate)
    {
        foreach (Zone zone in zones)
        {
            zone.elements.SetActive(false);
        }
        zones[zoneToActivate].elements.SetActive(true);
        currentSwapPercent = zones[zoneToActivate].swapTimePercent;
    }

    public void ResetForNewSeason()
    {
        Swap(0);
        zoneIndex = 0;
    }
}
