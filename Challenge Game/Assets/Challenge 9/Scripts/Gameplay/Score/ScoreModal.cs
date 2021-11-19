using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class ScoreModal : MonoBehaviour
    {
        public GameOverHandler gameOverHandler;

        public Button ConfirmButton;

        public Text ScoreText;

        private void Start()
        {
            ConfirmButton.onClick.AddListener(() => { gameOverHandler.ReturnToMainMenu(); });
            gameObject.SetActive(false);
        }

        public void ShowText(int Score)
        {
            ScoreText.text = $"Your score is\n{Score}";
            gameObject.SetActive(true);
        }
    }
}
