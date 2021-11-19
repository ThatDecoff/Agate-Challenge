using UnityEngine;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class ScorePanel : MonoBehaviour
    {
        public Text NameText;
        public Text ScoreText;

        public void UpdateView(string Name, int Score)
        {
            NameText.text = Name;
            ScoreText.text = $"{Score}";
        }
    }
}
