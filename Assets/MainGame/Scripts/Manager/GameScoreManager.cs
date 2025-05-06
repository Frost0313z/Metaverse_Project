using UnityEngine;

public static class ScoreManager
{
    public static void SaveScore(MinigameType type, int score)
    {
        string key = GetKey(type); // 미니게임 타입에 따라서 자동으로 키 값 만들기
        PlayerPrefs.SetInt(key, score);
        PlayerPrefs.Save();
    }

    public static int GetScore(MinigameType type)
    {
        string key = GetKey(type);
        return PlayerPrefs.GetInt(key, 0); // 기본값 0
    }

    private static string GetKey(MinigameType type)
    {
        return type switch
        {
            MinigameType.Flappy => "FlappyScore",
            MinigameType.Stack => "StackScore",
            MinigameType.TopDown => "TopDownScore",
            _ => "UnknownScore"
        };
    }
}