using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class BunnyCounter : MonoBehaviour
{
    public int numberOfBunnies { get; private set; }
    public UnityEvent<BunnyCounter> OnBunniesCollected;
    public TrailRenderer trail;

    private void Start() {
        trail = GetComponent<TrailRenderer>();
        //trail.forceRenderingOff = true;
    }
    public void BunniesCollected()
    {
        numberOfBunnies++;
        Debug.Log("bunnycounter: collect");
        OnBunniesCollected.Invoke(this);

    }

    private void FixedUpdate() {

    }

}