using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static ScoreBoardManager;

public class PrisonDoorController : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase closedGateTile;  
    public TileBase openGateTile;  
    // 첫번째 문 - Flappy 미니게임 목표 점수 달성시 오픈  
    private Vector3Int gatePosition_first = new Vector3Int(-7, 6, 0);   
    // 두번째 문 - TopDown 미니게임 목표 점수 달성시 오픈
    private Vector3Int gatePosition_second = new Vector3Int(-1, 6, 0);
    // 세번째 문 - Stack 미니게임 목표 점수 달성시 오픈
    private Vector3Int gatePosition_third = new Vector3Int(5, 6, 0);

    void Start()
    {
        if (IsWin_Flappy)
        {
            tilemap.SetTile(gatePosition_first, openGateTile);
        }
        else
        {
            tilemap.SetTile(gatePosition_first, closedGateTile);
        }

        if (IsWin_Stack)
        {
            tilemap.SetTile(gatePosition_second, openGateTile);
        }
        else
        {
            tilemap.SetTile(gatePosition_second, closedGateTile);
        }

        if (IsWin_TopDown)
        {
            tilemap.SetTile(gatePosition_third, openGateTile);
        }
        else
        {
            tilemap.SetTile(gatePosition_third, closedGateTile);
        }
    }
}
