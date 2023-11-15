using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public static event Action onDeath;

    public LayerMask terrainLayer;
    public float speed;
    Rigidbody2D body;
    SpriteRenderer rendy;
    Color orange;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rendy = GetComponent<SpriteRenderer>();
        orange = rendy.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        rendy.color = IsGrounded() ? orange : Color.white;
        float jumpAdder = 0;
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            jumpAdder = 5;
        }
        
        body.velocity = new Vector2(speed, body.velocity.y + jumpAdder);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Die();
    }

    // https://kylewbanks.com/blog/unity-2d-checking-if-a-character-or-object-is-on-the-ground-using-raycasts
    bool IsGrounded() { 
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.7f;

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
