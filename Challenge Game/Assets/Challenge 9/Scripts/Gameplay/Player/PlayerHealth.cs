using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class PlayerHealth : MonoBehaviour
    {
        public int baseHp = 3;

        public GameOverHandler gameOverHandler;
        public Text HpText;

        private int CurrentHp;

        private void Start()
        {
            CurrentHp = baseHp;
            UpdateView();
        }

        public void DecrementHp(int amount)
        {
            CurrentHp -= amount;
            CurrentHp = Mathf.Clamp(CurrentHp, 0, baseHp);

            UpdateView();
            if (CurrentHp <= 0)
            {
                Debug.Log($"{GetType()}: Ran out of HP");
                gameOverHandler.OnGameOver();
            }
        }

        private void UpdateView()
        {
            HpText.text = $"Lives : {CurrentHp}";
        }
    }
}
