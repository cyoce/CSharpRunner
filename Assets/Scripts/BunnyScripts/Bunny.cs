using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Bunny : MonoBehaviour
{
    float delay = 0f;
    static float baseDelay = 0.5f;
    float activationTime = 0f;
    bool following = false;
    TrailRenderer trail;

    private void OnTriggerEnter2D(Collider2D other)
    {
        BunnyCounter bunnyCounter = other.GetComponent<BunnyCounter>();

        if (bunnyCounter != null)
        {
            bunnyCounter.BunniesCollected();
            following = true;
            activationTime = Time.time;
            trail = bunnyCounter.trail;
            baseDelay += 0.5f;
            delay = baseDelay;
        }
    }

    private void Update() {
        if(following && Time.time - activationTime >= delay) {
            float index = (trail.positionCount - 1) * (1 - delay / trail.time);
            int undershootIndex = Mathf.FloorToInt(index);
            Vector3 undershoot = trail.GetPosition(undershootIndex);
            Vector3 overshoot = trail.GetPosition(Mathf.CeilToInt(index));
            transform.position = Vector3.Lerp(undershoot, overshoot, index - undershootIndex);
        }
    }
}
