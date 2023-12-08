using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Bunny : MonoBehaviour {
    float delay = 0f;
    static float baseDelay = 0f;
    float activationTime = 0f;
    bool following = false;
    Trail trail;
    PlayerControl player;
    Rigidbody2D rb;
    public float accel;

    private float coeff;

    private int jumpTriggers = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<BunnyCounter>(out BunnyCounter bunnyCounter)) {
            Debug.Log("bunny: collect");
            bunnyCounter.BunniesCollected();
            activationTime = Time.time;
            trail = bunnyCounter.GetComponent<Trail>();
            player = bunnyCounter.GetComponent<PlayerControl>();
            //baseDelay += 0.1f;
            delay = baseDelay;
        } else if(other.tag == "Jump") {
            if(jumpTriggers == 0) {
                Debug.Log("jump");
                rb.velocity += Vector2.up * player._jumpVel;
            }
            ++jumpTriggers;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            List<Collider2D> colliders = new();
            rb.GetAttachedColliders(colliders);
            foreach(var item in colliders) {
                if(item.enabled == false) {
                    item.enabled = true;
                }
            };
            rb.gravityScale = collision.GetComponent<Rigidbody2D>().gravityScale;
            following = true;
        }
        if(collision.tag == "Jump") {
            --jumpTriggers;
        }
    }
    private void OnDrawGizmos() {
        //Handles.Label(transform.position, coeff.ToString("0.00"));
    }
    private void FixedUpdate() {
        if(following && Time.time - activationTime >= delay) {

            float dist = transform.position.x - player.transform.position.x;
            //coeff = 1 + Mathf.Pow(dist - 1, -1);
            coeff = Mathf.Max(2 / (Mathf.Pow(1.5f, (dist+1)/2) + 1) - 1, 0);
            Vector3 offset = transform.position + Vector3.up * 0.5f;
            rb.AddForceAtPosition(Vector3.right * accel, offset);
            rb.AddForce(Vector3.left * rb.velocity.x * coeff);
            rb.velocity *= Mathf.Pow(coeff, Time.fixedDeltaTime);
            if(rb.velocity.x > player.speed) {
                //rb.velocity = new(player.speed, rb.velocity.y);
            }
            /*
            TrailPoint dest = trail.GetPosition(Time.time - delay);
            //transform.position = dest.position;
            GetComponent<Rigidbody2D>().velocity = dest.velocity;
            */
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<Bunny>(out Bunny other)) {
            if(other.transform.position.x > transform.position.x) {
                /*activationTime = Time.time;
                delay = 1f;*/
                // + 0.4f - baseDelay;
                //other.GetComponent<Rigidbody2D>().AddForce(Vector3.up * accel, ForceMode2D.Impulse);
                
             
                

            }
            float impulse = 100f;
            //rb.AddForce(collision.relativeVelocity * impulse, ForceMode2D.Impulse);
        } else if(collision.gameObject.layer == 3){
            /*if(collision.GetContact(0).normal.y > 0) {
                rb.velocity = new(rb.velocity.x, 0);
            }*/
        }
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
}
