using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour {
    public static event Action onDeath;

    public LayerMask terrainLayer;
    public float speed;
    public GameObject jumpMarker;

    Rigidbody2D body;
    SpriteRenderer rendy;
    Color orange;
    bool isDead = false;

    public float jumpHeight;
    public float airTime;

    public float _jumpVel;
    private float gravScale;
    void CalcGrav() {
        // 2T = AirTime
        // T = jumpVel / gravScale => jumpVel = gravScale * T
        // => gravScale = jumpVel / T
        // JumpHeight = jumpVel^2 / 2*gravScale
        // gravScale = jumpVel^2 / 2*JumpHeight
        // jumpVel^2 / gravScale = 2*JumpHeight
        // jumpVel^2 / (jumpVel/T) = 2*JumpHeight
        // jumpVel * T = 2*JumpHeight
        // jumpVel = 2*JumpHeight / T = 4*JumpHeight / AirTime

        _jumpVel = 4 * jumpHeight / airTime;
        gravScale = _jumpVel / (airTime / 2);
        body.gravityScale = gravScale / 9.81f;

    }

    private bool canJump=false, couldJump=false;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        rendy = GetComponent<SpriteRenderer>();
        orange = rendy.color;
        CalcGrav();
    }

    // Update is called once per frame
    void Update() {

        if(isDead) return;
        rendy.color = IsGrounded() ? orange : Color.white;
        float jumpAdder = body.velocity.y;
        couldJump = canJump;
        canJump = Input.GetKey(KeyCode.Space) && IsGrounded();
        if(canJump && !couldJump) {
            jumpAdder = _jumpVel;
            //GetComponent<Trail>().AddPoint();
            GameObject marker = Instantiate(jumpMarker);
            marker.transform.position = transform.position;
        }

        body.velocity = new Vector2(speed, jumpAdder);
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 point = contact.normal;
        Debug.DrawLine(contact.point, contact.point + 5 * contact.normal);
        if(false && Mathf.Abs(point.x) > Mathf.Abs(point.y) && collision.gameObject.layer == 3) {
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
