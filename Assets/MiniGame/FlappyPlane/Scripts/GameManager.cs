using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGame.Flappy
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager uIManager;
        static GameManager gameManager; // 싱글톤 선언언
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;

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
            ScoreManager.SaveScore(MinigameType.Flappy, currentScore);
            uIManager.SetRestart();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            uIManager.updatescore(currentScore);
        }
    }
}
