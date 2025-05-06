using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MinigameType
{
    Flappy,
    Stack,
    TopDown
}

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;

    public MinigameType CurrentMinigame;

    private void Awake() // 외부에서 호출하기 쉽도록 싱글톤 패턴으로 작성
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMinigame(MinigameType type) // 외부에서 호출하는 용도임
    {
        CurrentMinigame = type;

        string sceneName = type 
        switch
        {
            MinigameType.Flappy => "FlappyScene",
            MinigameType.Stack => "StackScene",
            MinigameType.TopDown => "TopDownScene",
            _ => "MainGameScene"
        };

        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}