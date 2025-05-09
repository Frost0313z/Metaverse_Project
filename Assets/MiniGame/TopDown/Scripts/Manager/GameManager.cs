using UnityEngine;
using MiniGame.TopDown;

namespace MiniGame.TopDown
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public PlayerController player { get; private set; }
        private ResourceController _playerResourceController;

        [SerializeField] private int currentWaveIndex = 0;

        private EnemyManager enemyManager;
        private UIManager uiManager;
        public static bool isFirstLoading = true;


        private void Awake()
        {
            instance = this;
            player = FindObjectOfType<PlayerController>();
            player.Init(this);

            uiManager = FindObjectOfType<UIManager>();

            enemyManager = GetComponentInChildren<EnemyManager>();
            enemyManager.Init(this);

            _playerResourceController = player.GetComponent<ResourceController>();
            _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
            _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                StartGame();
            }
            else
            {
                isFirstLoading = false;
            }
        }


        public void StartGame()
        {
            uiManager.SetPlayGame();
            StartNextWave();
        }

        void StartNextWave()
        {
            currentWaveIndex += 1;
            enemyManager.StartWave(1 + currentWaveIndex / 5);
            uiManager.ChangeWave(currentWaveIndex);
        }

        public void EndOfWave()
        {
            StartNextWave();
        }

        public void GameOver()
        {
            enemyManager.StopWave();
            PlayerPrefs.SetInt("TopDownScore", currentWaveIndex);
            uiManager.SetGameOver();
        }
    }
}

