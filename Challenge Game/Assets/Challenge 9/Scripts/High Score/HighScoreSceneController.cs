using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class HighScoreSceneController : MonoBehaviour
    {
        public HighScoreHandler highScoreHandler;

        public ScorePanel prefab;
        public Transform HighScoreParent;

        public Button ResetButton;
        public Button BackButton;

        private List<ScorePanel> scorePanel = new List<ScorePanel>();

        private void Start()
        {
            highScoreHandler.Start();

            SetupView();

            ResetButton.onClick.AddListener(ResetScore);
            BackButton.onClick.AddListener(ReturnToMainMenu);
        }

        private void SetupView()
        {
            foreach(ScorePanel panel in scorePanel)
            {
                Destroy(panel.gameObject);
            }
            scorePanel.Clear();

            foreach (ScoreData data in highScoreHandler.highScoreData.scores)
            {
                ScorePanel obj = Instantiate(prefab, HighScoreParent);
                obj.UpdateView(data.Name, data.Score);
                scorePanel.Add(obj);
            }
        }

        private void ResetScore()
        {
            highScoreHandler.ResetData();
            SetupView();
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("9-MainMenu", LoadSceneMode.Single);
        }
    }
}
