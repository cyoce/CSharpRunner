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
        //rendy.color = feet.IsTouchingLayers(1 << 3) ? orange : Color.white;
        float jumpAdder = 0;
        if(Input.GetKeyDown(KeyCode.Space)) {
            jumpAdder = 5;
        }
        body.velocity = new Vector2(speed, body.velocity.y + jumpAdder);
    }
}
