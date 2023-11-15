using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour {
    // Start is called before the first frame update
    public Tilemap terrainMap;
    public Tilemap obstacleMap;
    public TileBase groundBlock;
    public TileBase obstacle;

    public static event Action nextBlock;

    int groundHeight = -1;


    System.Random rand = new System.Random();

    void Start() {

        (Vector3Int leftCoord, Vector3Int rightCoord) = CamBounds();
        while(leftCoord.x <= rightCoord.x) {
            terrainMap.SetTile(leftCoord, groundBlock);
            ++leftCoord.x;
        }

    }

    Tuple<Vector3Int, Vector3Int> CamBounds() {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 offset = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);
        Vector3 leftPos = camPos - offset;
        Vector3 rightPos = camPos + offset;
        Vector3Int leftCoord = terrainMap.WorldToCell(leftPos);
        Vector3Int rightCoord = terrainMap.WorldToCell(rightPos);
        leftCoord.y = rightCoord.y = groundHeight;
        return new Tuple<Vector3Int, Vector3Int>(leftCoord, rightCoord);
    }

    // Update is called once per frame
    void Update() {
        Vector3Int rightBound = CamBounds().Item2;
        if(terrainMap.GetTile(rightBound) == null) {
            terrainMap.SetTile(rightBound, groundBlock);
            nextBlock?.Invoke();
            if(rand.Next(100) <= 15) {
                obstacleMap.SetTile(rightBound + new Vector3Int(0, 1, 0), obstacle);
            }
        }
    }
}
