using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;


public class Bunny : MonoBehaviour {
    float delay = 0f;
    static float baseDelay = 0f;
    float activationTime = 0f;
    bool following = false;
    Trail trail;
    PlayerControl player;
    Rigidbody2D rb;
    Animator anim;
    public float accel;
    public AudioClip bunnySound;

    private float coeff;

    private int jumpTriggers = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<BunnyCounter>(out BunnyCounter bunnyCounter)) {
            Debug.Log("bunny: collect");
            bunnyCounter.BunniesCollected();
            AudioSource.PlayClipAtPoint(bunnySound, transform.position);
            activationTime = Time.time;
            trail = bunnyCounter.GetComponent<Trail>();
            player = bunnyCounter.GetComponent<PlayerControl>();
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
            anim.SetTrigger("BunnyFollowing");
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
    private void FixedUpdate() {
        if(following && Time.time - activationTime >= delay) {

            float dist = transform.position.x - player.transform.position.x;
            coeff = Mathf.Max(2 / (Mathf.Pow(1.5f, (dist+1)/2) + 1) - 1, 0);
            Vector3 offset = transform.position + Vector3.up * 0.5f;
            rb.AddForceAtPosition(Vector3.right * accel, offset);
            rb.AddForce(Vector3.left * rb.velocity.x * coeff);
            rb.velocity *= Mathf.Pow(coeff, Time.fixedDeltaTime);
        }
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

}
