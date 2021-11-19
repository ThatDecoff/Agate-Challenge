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
        public Button BackButton;

        private void Start()
        {
            highScoreHandler.Start();
            foreach(ScoreData data in highScoreHandler.highScoreData.scores)
            {
                ScorePanel obj = Instantiate(prefab, HighScoreParent);
                obj.UpdateView(data.Name, data.Score);
            }

            BackButton.onClick.AddListener(ReturnToMainMenu);
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("9-MainMenu", LoadSceneMode.Single);
        }
    }
}
