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

        public void ShowText(int Score)
        {
            Debug.Log($"{GetType()}: Show Score Modal");

            ScoreText.text = $"Your score is\n{Score}";

            ConfirmButton.onClick.RemoveAllListeners();
            ConfirmButton.onClick.AddListener(() => { gameOverHandler.ReturnToMainMenu(); });

            gameObject.SetActive(true);
        }
    }
}
