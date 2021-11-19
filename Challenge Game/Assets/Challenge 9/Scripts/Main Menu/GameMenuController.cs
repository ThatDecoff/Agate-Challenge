using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.Challenge9
{
    public class GameMenuController : MonoBehaviour
    {
        public Button PlayButton;
        public Button HighScoreButton;
        public Button ExitButton;

        private void Start()
        {
            PlayButton.onClick.AddListener(() => { SceneManager.LoadScene("9-Gameplay", LoadSceneMode.Single); });
            HighScoreButton.onClick.AddListener(() => { SceneManager.LoadScene("9-HighScore", LoadSceneMode.Single); });
            ExitButton.onClick.AddListener(() => { Application.Quit(); });
        }
    }
}
