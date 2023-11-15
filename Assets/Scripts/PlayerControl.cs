using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour {
    public static event Action onDeath;

    public LayerMask terrainLayer;
    public float speed;

    Rigidbody2D body;
    SpriteRenderer rendy;
    Color orange;
    bool isDead = false;

    private bool canJump=false, couldJump=false;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        rendy = GetComponent<SpriteRenderer>();
        orange = rendy.color;

    }

    // Update is called once per frame
    void Update() {
        if(isDead) return;
        rendy.color = IsGrounded() ? orange : Color.white;
        float jumpAdder = body.velocity.y;
        couldJump = canJump;
        canJump = Input.GetKey(KeyCode.Space) && IsGrounded();
        if(canJump && !couldJump) {
            jumpAdder = 5;
            Debug.Log("jump");
        }

        body.velocity = new Vector2(speed, jumpAdder);
    }



    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("bounce");
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 point = contact.normal;
        Debug.DrawLine(contact.point, contact.point + 5 * contact.normal);
        if(Mathf.Abs(point.x) > Mathf.Abs(point.y)) {
            Die();
        }
    }

    // https://kylewbanks.com/blog/unity-2d-checking-if-a-character-or-object-is-on-the-ground-using-raycasts
    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.6f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, terrainLayer);
        if(hit.collider != null) {
            return true;
        }

        return false;
    }

    void Die() {
        onDeath?.Invoke();
        Debug.Log("dead");
        body.simulated = false;
        rendy.color = Color.black;
        isDead = true;
    }
}
