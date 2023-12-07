using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Bunny : MonoBehaviour {
    float delay = 0f;
    static float baseDelay = 0.1f;
    float activationTime = 0f;
    bool following = false;
    Trail trail;


    private void OnTriggerEnter2D(Collider2D other) {
        BunnyCounter bunnyCounter = other.GetComponent<BunnyCounter>();

        if(bunnyCounter != null) {
            bunnyCounter.BunniesCollected();
            following = true;
            activationTime = Time.time;
            trail = bunnyCounter.GetComponent<Trail>();
            baseDelay += 0.1f;
            delay = baseDelay;
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            foreach(var item in GetComponents<BoxCollider2D>()) {
                if(item.enabled == false) {
                    item.enabled = true;
                }
            };
            GetComponent<Rigidbody2D>().gravityScale = collision.GetComponent<Rigidbody2D>().gravityScale;
            Debug.Log(GetComponent<Rigidbody2D>().gravityScale);
        }
    }
    */

    private void FixedUpdate() {
        if(following && Time.time - activationTime >= delay) {
            TrailPoint dest = trail.GetPosition(Time.time - delay);
            transform.position = dest.position;
            //GetComponent<Rigidbody2D>().velocity = dest.velocity;
        }
    }
}
