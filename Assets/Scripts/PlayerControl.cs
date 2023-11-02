using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Rigidbody2D body;
    Collider2D collider;
    Collider2D feet;
    SpriteRenderer rendy;
    Color orange;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        feet = GetComponentInChildren<Collider2D>();
        rendy = GetComponent<SpriteRenderer>();
        orange = rendy.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        rendy.color = isGrounded ? orange : Color.white;
        float jumpAdder = 0;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            jumpAdder = 5;
        }
        
        body.velocity = new Vector2(speed, body.velocity.y + jumpAdder);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        foreach(ContactPoint2D contact in collision.contacts){
            if(Mathf.Abs(contact.point.x - collider.bounds.center.x) < collider.bounds.extents.x) {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    }
}
