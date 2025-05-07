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

    [Header("문 위치")]
    // 첫번째 문 - Flappy 미니게임 목표 점수 달성시 오픈  
    private Vector3Int gatePosition_first = new Vector3Int(-7, 6, 0);   
    // 두번째 문 - TopDown 미니게임 목표 점수 달성시 오픈
    private Vector3Int gatePosition_second = new Vector3Int(-1, 6, 0);
    // 세번째 문 - Stack 미니게임 목표 점수 달성시 오픈
    private Vector3Int gatePosition_third = new Vector3Int(5, 6, 0);

    [Header("충돌 오브젝트")]
    public GameObject collider_first;
    public GameObject collider_second;
    public GameObject collider_third;

    void Update()
    {
        if (IsWin_Flappy)
        {
            tilemap.SetTile(gatePosition_first, openGateTile);
            collider_first.SetActive(false);
        }
        else
        {
            tilemap.SetTile(gatePosition_first, closedGateTile);
            collider_first.SetActive(true);
        }

        if (IsWin_Stack)
        {
            tilemap.SetTile(gatePosition_second, openGateTile);
            collider_second.SetActive(false);
        }
        else
        {
            tilemap.SetTile(gatePosition_second, closedGateTile);
            collider_second.SetActive(true);
        }

        if (IsWin_TopDown)
        {
            tilemap.SetTile(gatePosition_third, openGateTile);
            collider_third.SetActive(false);
        }
        else
        {
            tilemap.SetTile(gatePosition_third, closedGateTile);
            collider_third.SetActive(true);
        }
    }
}
