using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScoreBoardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore_Flappy;
    [SerializeField] private TextMeshProUGUI highScore_Stack;
    [SerializeField] private TextMeshProUGUI highScore_TopDown;
    // 점수 UI 설정
    [SerializeField] private GameObject ScoreBoard_Flappy;
    [SerializeField] private GameObject ScoreBoard_Stack;
    [SerializeField] private GameObject ScoreBoard_TopDown;
    // 목표 점수 설정
    [SerializeField] private int TargetScore_Flappy = 30;
    [SerializeField] private int TargetScore_Stack = 30;
    [SerializeField] private int TargetScore_TopDown = 30;

    public int bestScore_Flappy;
    public int bestScore_Stack;
    public int bestScore_TopDown;
    public static bool IsWin_Flappy = false;
    public static bool IsWin_Stack = false;
    public static bool IsWin_TopDown = false;
    public Tilemap tilemap;
    public TileBase closedGateTile_first;  // 기존 닫힌 문
    public TileBase openGateTile_first;    // 열린 문
    public Vector3Int gatePosition_first;  // 문 타일의 위치 (Cell 좌표)  
    public TileBase closedGateTile_second;  // 기존 닫힌 문
    public TileBase openGateTile_second;    // 열린 문
    public Vector3Int gatePosition_second;  // 문 타일의 위치 (Cell 좌표)  
    public TileBase closedGateTile_third;  // 기존 닫힌 문
    public TileBase openGateTile_third;    // 열린 문
    public Vector3Int gatePosition_third;  // 문 타일의 위치 (Cell 좌표)  
    void Start()
    {
        if (GameSceneManager.Instance != null)
        {
            switch (GameSceneManager.Instance.CurrentMinigame)
            {
                case MinigameType.Flappy:
                    ShowFlappyScore();
                    CheckWinCondition(MinigameType.Flappy);
                    break;
                case MinigameType.Stack:
                    ShowStackScore();
                    CheckWinCondition(MinigameType.Stack);
                    break;
                case MinigameType.TopDown:
                    ShowTopDownScore();
                    CheckWinCondition(MinigameType.TopDown);
                    break;
                default:
                    Debug.Log("이전 미니게임 정보 없음");
                    break;
            }
        }
    }

    public void ShowFlappyScore()
    {
        bestScore_Flappy = ScoreManager.GetScore(MinigameType.Flappy);
        highScore_Flappy.text = bestScore_Flappy.ToString();

        ScoreBoard_Flappy.gameObject.SetActive(true);
        ScoreBoard_Stack.gameObject.SetActive(false);
        ScoreBoard_TopDown.gameObject.SetActive(false);

    }

    public void ShowStackScore()
    {
        bestScore_Stack = ScoreManager.GetScore(MinigameType.Stack);
        highScore_Stack.text = bestScore_Stack.ToString();

        ScoreBoard_Flappy.gameObject.SetActive(false);
        ScoreBoard_Stack.gameObject.SetActive(true);
        ScoreBoard_TopDown.gameObject.SetActive(false);

    }

    public void ShowTopDownScore()
    {
        bestScore_TopDown = ScoreManager.GetScore(MinigameType.TopDown);
        highScore_TopDown.text = bestScore_TopDown.ToString();

        ScoreBoard_Flappy.gameObject.SetActive(false);
        ScoreBoard_Stack.gameObject.SetActive(false);
        ScoreBoard_TopDown.gameObject.SetActive(true);

    }

    private void CheckWinCondition(MinigameType type)
    {
        switch (type)
        {
            case MinigameType.Flappy:
                bestScore_Flappy = ScoreManager.GetScore(MinigameType.Flappy);
                if (bestScore_Flappy > TargetScore_Flappy)
                    IsWin_Flappy = true;
                break;

            case MinigameType.Stack:
                bestScore_Stack = ScoreManager.GetScore(MinigameType.Stack);
                if (bestScore_Stack > TargetScore_Stack)
                    IsWin_Stack = true;
                break;

            case MinigameType.TopDown:
                bestScore_TopDown = ScoreManager.GetScore(MinigameType.TopDown);
                if (bestScore_TopDown > TargetScore_TopDown)
                    IsWin_TopDown = true;
                break;
        }
    }
}
