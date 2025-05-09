using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.TopDown
{
    public class HomeUI : BaseUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickStartButton()
        {
            GameManager.instance.StartGame();
        }

        public void OnClickExitButton()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene");
        }

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }
    }
}