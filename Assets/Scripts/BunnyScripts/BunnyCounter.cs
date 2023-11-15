using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCounter : MonoBehaviour
{
    public int numberOfBunnies { get; private set; }

    public void BunniesCollected()
    {
        numberOfBunnies++;
    }
}
