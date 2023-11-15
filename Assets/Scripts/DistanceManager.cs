using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistanceManager : MonoBehaviour
{
    public TMP_Text distanceRanText;
    public int distanceRan = 0;
    public float elapsedSeconds = 0f;
    public bool gameOver = false;
    void Start()
    {
            
    }

    void Update()
    {
       if (gameOver != true)
        {
            float presentTime = Time.deltaTime;
            elapsedSeconds += presentTime;
            distanceRan = (int)elapsedSeconds;

            distanceRanText.text = "Distance Ran: " + distanceRan.ToString() + " Miles";
            
        }
    }
}
