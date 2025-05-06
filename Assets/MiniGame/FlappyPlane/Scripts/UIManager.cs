using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Flappy
{
    public class UIManager : MonoBehaviour
    {

        public TextMeshProUGUI scoreText;
        public Button restartButton;
        public Button quitButton;

        void Start()
        {
            if (restartButton == null)
                Debug.LogError("restart Button is null");

            if (quitButton == null)
                Debug.LogError("quit Button is null");

            if (scoreText == null)
                Debug.LogError("score text is null");

            restartButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);

            restartButton.onClick.AddListener(SetRestart);
            quitButton.onClick.AddListener(QuitGame);
        }


        public void SetRestart()
        {
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }

        public void QuitGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene");
        }

        public void updatescore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
