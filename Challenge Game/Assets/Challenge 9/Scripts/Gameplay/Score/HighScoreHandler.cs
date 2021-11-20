using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace Game.Challenge9
{
    public class HighScoreHandler : MonoBehaviour
    {
        public HighScoreObject highScoreData;

        public int DefaultScore = 25;

        public void Start()
        {
            if (PlayerPrefs.HasKey("SaveData"))
            {
                Load();
            }
            else
            {
                ResetData();
            }
            Save();
        }

        public void ResetData()
        {
            List<ScoreData> newData = new List<ScoreData>();
            for(int i = 0; i < 10; i++)
            {
                ScoreData obj = new ScoreData("ABC", DefaultScore);
                newData.Add(obj);
            }
            highScoreData.scores = newData;
            Save();
        }

        public void AddData(ScoreData data)
        {
            highScoreData.scores.Add(data);
            highScoreData.scores.Sort(ScoreData.ScoreDataCompare);
            highScoreData.scores.Reverse();

            List<ScoreData> newData = new List<ScoreData>();
            for (int i = 0; i < 10; i++)
            {
                newData.Add(highScoreData.scores[i]);
            }
            highScoreData.scores = newData;
            Save();
        }

        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            bf.Serialize(file, highScoreData.ToSaveData());
            file.Close();
            Debug.Log("Game data saved!");
            PlayerPrefs.SetInt("SaveData", 1);
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
                highScoreData.FromSaveData((HighScoreSaveData)bf.Deserialize(file));
                file.Close();
                Debug.Log("Game data loaded!");
            }
            else
            {
                Debug.LogError("There is no save data!");
            }
        }
    }
}
