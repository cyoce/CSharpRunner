using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bunny : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BunnyCounter bunnyCounter = other.GetComponent<BunnyCounter>();

        if (bunnyCounter != null)
        {
            bunnyCounter.BunniesCollected();
            gameObject.SetActive(false);
        }
    }
}
