using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class DangerObjectCreator : ObjectCreator
    {
        public GameOverHandler gameOverHandler;
        public PlayerHealth playerHp;

        public int Damage = 1;

        protected override void OnDespawn(BaseObject obj)
        {
            playerHp.DecrementHp(Damage);

            AddToDespawned(obj);

            Invoke("SpawnObject", 3);
        }
    }
}
