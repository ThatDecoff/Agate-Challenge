using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class DangerObjectCreator : ObjectCreator
    {
        protected override void OnDespawn(BaseObject obj)
        {
            AddToDespawned(obj);

            Invoke("SpawnObject", 3);
        }
    }
}
