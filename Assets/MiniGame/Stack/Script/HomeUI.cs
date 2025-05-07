using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace MiniGame.Stack
{
    public class HomeUI : BaseUI
    {
        Button startButton;
        Button exitButton;

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }

        public override void Init(UIManager_Stack uiManager)
        {
            base.Init(uiManager);

            startButton = transform.Find("StartButton").GetComponent<Button>();
            exitButton = transform.Find("ExitButton").GetComponent<Button>();

            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        void OnClickStartButton()
        {
            uIManager.OnClickStart();
        }

        void OnClickExitButton()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene");
        }
    }
}

