using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public LayerMask terrainLayer;
    public float speed;
    Rigidbody2D body;
    Collider2D collider;
    Collider2D feet;
    SpriteRenderer rendy;
    Color orange;
    int groundContacts = 0;
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
        /*ContactPoint2D[] contacts = new ContactPoint2D[100];
        collider.GetContacts(contacts);
        ++groundContacts;
        foreach(ContactPoint2D contact in contacts) {
            if(Mathf.Abs(contact.point.x - collider.bounds.center.x) < collider.bounds.extents.x) {
                ++groundContacts;
                break;
            }
        }*/
        rendy.color = IsGrounded() ? orange : Color.white;
        float jumpAdder = 0;
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            jumpAdder = 5;
        }
        
        body.velocity = new Vector2(speed, body.velocity.y + jumpAdder);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision) {
        foreach(ContactPoint2D contact in collision.contacts){
            if(Mathf.Abs(contact.point.x - collider.bounds.center.x) < collider.bounds.extents.x) {
                ++groundContacts;
                break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        --groundContacts;
    }
    //*/
    
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

}
