using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTestButton : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase testTile;
    public Vector3Int testPosition = new Vector3Int(-7, 6, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tilemap.SetTile(testPosition, testTile);
            Debug.Log($"T키 입력됨 → {testPosition} 위치에 {testTile.name} 설정됨");
        }
    }
}
