using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class ScoreHandler : MonoBehaviour
    {
        public int Score = 0;

        public HighScoreHandler highScoreHandler;

        public Text ScoreText;

        private void Start()
        {
            SetView();
        }

        public void AddScore(int value)
        {
            Score += value;
            SetView();
        }

        public void SetScore(int value)
        {
            Score = value;
            SetView();
        }

        public bool CheckNewHighScore()
        {
            List<ScoreData> data = highScoreHandler.highScoreData.scores;
            return data[data.Count - 1].Score < Score;
        }

        public void SetHighScore(string Name)
        {
            highScoreHandler.AddData(new ScoreData(Name, Score));
        }

        private void SetView()
        {
            ScoreText.text = $"Point : {Score}";
        }
    }
}
