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
        Debug.Log($"IsWin_Flappy: {IsWin_Flappy}, IsWin_Stack: {IsWin_Stack}, IsWin_TopDown: {IsWin_TopDown}");

    Debug.Log($"Tilemap name: {tilemap.name}");

    Debug.Log($"현재 위치 플래피 문: {tilemap.GetTile(gatePosition_first)?.name}");
        // ScoreBoardManager.CheckWinCondition(MinigameType.Flappy);

        if (IsWin_Flappy)
        {
            tilemap.SetTile(gatePosition_first, openGateTile);
            Debug.Log("Flappy 문 OPEN");
        }
        else
        {
            tilemap.SetTile(gatePosition_first, closedGateTile);
            Debug.Log("Flappy 문 CLOSED");
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

        Debug.Log($"변경 후 Flappy 위치 타일: {tilemap.GetTile(gatePosition_first)?.name}");
    }
}
