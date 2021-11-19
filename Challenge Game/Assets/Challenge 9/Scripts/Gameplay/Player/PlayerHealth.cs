using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class PlayerHealth : MonoBehaviour
    {
        public int baseHp = 3;

        private int CurrentHp;

        private void Start()
        {
            CurrentHp = baseHp;
        }

        public void DecrementHp(int amount)
        {
            CurrentHp -= amount;
            CurrentHp = Mathf.Clamp(CurrentHp, 0, baseHp);
        }
    }
}
