using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Challenge9
{
    public class GameOverHandler : MonoBehaviour
    {
        public ConfirmModal Modal;
        public ScoreModal scoreModal;
        public HighScoreModal highScoreModal;

        public ScoreHandler scoreHandler;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Modal.ShowModal("Quit Game", "Are you sure you want to quit?", ReturnToMainMenu, ResumeGame);
                Time.timeScale = 0f;
            }
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("9-MainMenu", LoadSceneMode.Single);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }

        public void OnGameOver()
        {
            Time.timeScale = 0f;
            if (scoreHandler.CheckNewHighScore())
            {
                highScoreModal.ShowText(scoreHandler.Score, scoreHandler.SetHighScore);
            }
            else
            {
                scoreModal.ShowText(scoreHandler.Score);
            }
        }
    }
}
