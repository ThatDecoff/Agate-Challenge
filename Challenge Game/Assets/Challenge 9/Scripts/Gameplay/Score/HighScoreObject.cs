using UnityEngine;
using System.Collections.Generic;

namespace Game.Challenge9
{
    [CreateAssetMenu(fileName="new HighScoreObject", menuName="HighScore")]
    public class HighScoreObject : ScriptableObject
    {
        public List<ScoreData> scores;

        public HighScoreSaveData ToSaveData()
        {
            HighScoreSaveData data = new HighScoreSaveData();
            data.scores = scores;
            return data;
        }

        public void FromSaveData(HighScoreSaveData data)
        {
            scores = data.scores;
        }
    }

    [System.Serializable]
    public class HighScoreSaveData
    {
        public List<ScoreData> scores;
    }
}
