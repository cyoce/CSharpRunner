using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileReplication : MonoBehaviour {
    // USE TILEMAP INSTEAD
    static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible() {
        ++count;
        Instantiate(gameObject, transform.position + new Vector3(1, 0, 1), Quaternion.identity);
        Debug.Log(count);
    }
    private void OnBecameInvisible() {
        --count;
        Destroy(gameObject);
    }
}
