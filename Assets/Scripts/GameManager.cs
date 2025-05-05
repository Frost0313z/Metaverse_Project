using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager; // 싱글톤 선언언
    public static GameManager Instance {get{return gameManager;}}

    private int currentScore = 0;

    UIManager uIManager;
    public UIManager UIManager {get { return uIManager; } }

    private void Start()
    {
        uIManager.updatescore(0);
    }

    private void Awake()
    {
        gameManager = this;
        uIManager = FindObjectOfType<UIManager>();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uIManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uIManager.updatescore(currentScore);
    }
}
