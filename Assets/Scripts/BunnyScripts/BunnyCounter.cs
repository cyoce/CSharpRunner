using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BunnyCounter : MonoBehaviour
{
    public int numberOfBunnies { get; private set; }
    public UnityEvent<BunnyCounter> OnBunniesCollected;

    public void BunniesCollected()
    {
        numberOfBunnies++;
        OnBunniesCollected.Invoke(this);
    }
}
