using UnityEngine;
using UnityEngine.UI;
using System;

namespace Game.Challenge9
{
    public class HighScoreModal : MonoBehaviour
    {
        public GameOverHandler gameOverHandler;

        public Button ConfirmButton;

        public Text ScoreText;
        public InputField NameInput;

        public void ShowText(int Score, Action<string> OnButtonclick)
        {
            Debug.Log($"{GetType()}: Show HighScore Modal");

            ScoreText.text = $"Your score is\n{Score}";

            ConfirmButton.onClick.RemoveAllListeners();
            ConfirmButton.onClick.AddListener(() => { OnButtonclick.Invoke(NameInput.text); });
            ConfirmButton.onClick.AddListener(() => { gameOverHandler.ReturnToMainMenu(); });

            gameObject.SetActive(true);
        }
    }
}
