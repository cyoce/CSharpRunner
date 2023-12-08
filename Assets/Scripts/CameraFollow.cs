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
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new((transform.position + offset).x, camPos.y, camPos.z);
    }
}
