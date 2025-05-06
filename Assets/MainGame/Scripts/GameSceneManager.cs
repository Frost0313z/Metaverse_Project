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

    public MinigameType lastPlayedMinigame;

    public int flappyScore;
    public int stackScore;
    public int topDownScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않게
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 미니게임 씬 이동
    public void LoadMinigame(MinigameType type)
    {
        lastPlayedMinigame = type;

        if (type == MinigameType.Flappy)
            SceneManager.LoadScene("FlappyScene");
        else if (type == MinigameType.Stack)
            SceneManager.LoadScene("StackScene");
        else if (type == MinigameType.TopDown)
            SceneManager.LoadScene("TopDownScene");
    }

    // 점수 저장
    public void SaveScore(int score)
    {
        if (lastPlayedMinigame == MinigameType.Flappy)
            flappyScore = score;
        else if (lastPlayedMinigame == MinigameType.Stack)
            stackScore = score;
        else if (lastPlayedMinigame == MinigameType.TopDown)
            topDownScore = score;
    }

    // 메인 게임으로 돌아가기
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}