using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject Exit_Win;         
    [SerializeField] private GameObject Exit_Lose; 
    [SerializeField] private Button Exit_Win_okButton;
    [SerializeField] private Button Exit_Lose_yesButton;
    [SerializeField] private Button Exit_Lose_noButton;

    private void Start()
    {
        Exit_Win_okButton.onClick.AddListener(() =>
        {
            Exit_Win.SetActive(false);
        });

        Exit_Lose_yesButton.onClick.AddListener(() =>
        {
            switch (GameSceneManager.Instance.CurrentMinigame)
            {
                case MinigameType.Flappy:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyScene");
                    break;
                case MinigameType.Stack:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("StackScene");
                    break;
                case MinigameType.TopDown:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("TopDownScene");
                    break;
                default:
                    Debug.LogWarning("알 수 없는 미니게임 타입입니다.");
                    break;
            }
        });

        Exit_Lose_noButton.onClick.AddListener(() =>
        {
            Exit_Lose.SetActive(false);
        });
    }
}
