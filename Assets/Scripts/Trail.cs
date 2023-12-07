using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Trail : MonoBehaviour
{
    // Start is called before the first frame update
    List<TrailPoint> points;
    Rigidbody2D rb;
    void Start()
    {
        points = new();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(true || (int)(Time.time * 60) % 5 == 0) {
            AddPoint();
        }
    }

    public void AddPoint() {
        if(points.Count > 10000) {
            points.RemoveAt(0);
        }
        points.Add(new TrailPoint(transform.position, rb.velocity));
    }

    public int length { get => points.Count + 1; }

    TrailPoint GetPoint(int index) {
        return index == points.Count ? new TrailPoint(transform.position, rb.velocity) : points[index];
    }

    public TrailPoint GetPosition(float target) {
        int left = 0, right = length;
        do {
            int midpoint = (left + right) / 2;
            if(GetPoint(midpoint).time < target) {
                left = midpoint;
            } else {
                right = midpoint;
            }
        } while(left < right - 1);

        TrailPoint undershoot = GetPoint(left);
        TrailPoint overshoot = GetPoint(right);

        return TrailPoint.Lerp(undershoot, overshoot, target);
    }
}

public struct TrailPoint {
    public Vector3 position;
    public Vector3 velocity;
    public float time;

    public TrailPoint(Vector3 pos, Vector3 vel) : this(pos, vel, Time.time) { }
    
    public TrailPoint(Vector3 pos, Vector3 vel, float t) {
        position = pos;
        velocity = vel;
        time = t;
    }

    public static TrailPoint Lerp(TrailPoint a, TrailPoint b, float target) {
        float t = (target - a.time) / (b.time - a.time);
        Vector3 pos = Vector3.Lerp(a.position, b.position, t);
        Vector3 vel = Vector3.Lerp(a.velocity, b.velocity, t);
        return new TrailPoint(pos, vel, target);
    }
}