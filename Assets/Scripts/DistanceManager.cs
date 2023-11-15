using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistanceManager : MonoBehaviour
{
    public TMP_Text distanceRanText;
    public int distanceRan = 0;
    public bool gameOver = false;
    void Start()
    {
            
    }

    void Update()
    {
       if (gameOver != true)
        {
            DateTime presentTime = DateTime.Today;
            int secondsElapsed = presentTime.Second;
            distanceRan = secondsElapsed;

            distanceRanText.text = "Distance Ran: " + distanceRan.ToString() + " Miles";
        }
    }
}
