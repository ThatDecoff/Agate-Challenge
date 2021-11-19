using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class DangerObject : BaseObject
    {
        public int Damage = 1;

        protected override void OnPlayerEnter(GameObject player)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.DecrementHp(Damage);
            }
        }
    }
}
