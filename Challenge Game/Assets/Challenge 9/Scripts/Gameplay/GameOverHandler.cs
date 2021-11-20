using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Challenge9
{
    public class GameOverHandler : MonoBehaviour
    {
        public GameObject player;

        public ConfirmModal Modal;
        public ScoreModal scoreModal;
        public HighScoreModal highScoreModal;

        public ScoreHandler scoreHandler;

        public bool IsOver { get; private set; }
        public bool IsPaused { get; private set; }

        private void Start()
        {
            IsOver = false;
            IsPaused = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Modal.ShowModal("Quit Game", "Are you sure you want to quit?", ReturnToMainMenu, ResumeGame);
                //ReturnToMainMenu();
                IsPaused = true;
            }

            if(player.activeSelf && (IsOver || IsPaused))
            {
                player.SetActive(false);
            }
            else if(!player.activeSelf && (!IsOver && !IsPaused))
            {
                player.SetActive(true);
            }
        }

        public void ReturnToMainMenu()
        {
            IsOver = true;
            IsPaused = true;
            SceneManager.LoadScene("9-MainMenu", LoadSceneMode.Single);
        }

        public void ResumeGame()
        {
            IsPaused = false;
        }

        public void OnGameOver()
        {
            IsOver = true;
            Debug.Log($"{GetType()}: On Game Over {IsOver}");
            if (scoreHandler.CheckNewHighScore())
            {
                Debug.Log($"{GetType()}: HighScoreModal");
                highScoreModal.ShowText(scoreHandler.Score, scoreHandler.SetHighScore);
            }
            else
            {
                Debug.Log($"{GetType()}: ScoreModal");
                scoreModal.ShowText(scoreHandler.Score);
            }
        }
    }
}
