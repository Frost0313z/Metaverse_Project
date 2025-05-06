using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideUIHandler : MonoBehaviour
{
    [SerializeField] private Button okButton;

    private void Start()
    {
        okButton.onClick.AddListener(LoadMiniGame);
    }

    private void LoadMiniGame()
    {
        MinigameType type = GetMinigameType();
        GameSceneManager.Instance.LoadMinigame(type);
    }

    private MinigameType GetMinigameType()
    {
        string parentName = transform.parent.name;

        if (parentName.Contains("Flappy"))
            return MinigameType.Flappy;

        else if (parentName.Contains("Stack"))
            return MinigameType.Stack;

        else if (parentName.Contains("TopDown"))
            return MinigameType.TopDown;

        else
        {
            Debug.Log("미니게임 타입을 찾지 못해 기본값인 Flappy로 설정했습니다.");
            return MinigameType.Flappy;
        }
    }
}
