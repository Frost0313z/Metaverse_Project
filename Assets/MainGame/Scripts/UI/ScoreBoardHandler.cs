using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardHandler : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private GameObject Exit_Win;
    [SerializeField] private GameObject Exit_Lose;

    void Start()
    {
        okButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);    
            ShowResultUI();
        });
    }

    private void ShowResultUI()
    {
        if (GameSceneManager.Instance == null)
        {
            Debug.LogWarning("GameSceneManager 인스턴스가 없습니다.");
            return;
        }

        MinigameType type = GameSceneManager.Instance.CurrentMinigame;

        bool isWin = type switch
        {
            MinigameType.Flappy => ScoreBoardManager.IsWin_Flappy,
            MinigameType.Stack => ScoreBoardManager.IsWin_Stack,
            MinigameType.TopDown => ScoreBoardManager.IsWin_TopDown,
            _ => false
        };

        if (isWin)
        {
            Exit_Win.SetActive(true);
            Exit_Lose.SetActive(false);
        }
        else
        {
            Exit_Win.SetActive(false);
            Exit_Lose.SetActive(true);
        }
    }
}
