using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offset;
    void Start()
    {
        offset = Camera.main.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = transform.position + offset;
    }
}
