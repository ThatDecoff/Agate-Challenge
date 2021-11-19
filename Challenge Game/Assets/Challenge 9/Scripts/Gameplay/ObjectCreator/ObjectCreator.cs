using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public abstract class ObjectCreator : MonoBehaviour
    {
        public ObstacleHandler obstacleHandler;

        public BaseObject prefab;
        public Transform parent;
        public int ObjectCount;
        public int Offset;

        private List<BaseObject> objects = new List<BaseObject>();
        private List<BaseObject> despawned = new List<BaseObject>();
        private int RandomObjCount;

        private void Start()
        {
            RandomObjCount = Random.Range(ObjectCount - Offset, ObjectCount + Offset);
            Debug.Log($"{GetType()}: Randomized {RandomObjCount}");

            for (int i = 0; i < RandomObjCount; i++)
            {
                BaseObject obj = SpawnObject();
                objects.Add(obj);
                //obstacleHandler.AddObject(obj.gameObject);
            }
        }

        protected BaseObject SpawnObject()
        {
            BaseObject obj;
            if (despawned.Count == 0)
            {
                obj = Instantiate(prefab, parent);
                obj.OnDespawn += OnDespawn;
                obj.gameObject.SetActive(false);
            }
            else
            {
                obj = despawned[0];
                despawned.RemoveAt(0);
            }

            obj.transform.localPosition = FindNextAvailableSpot();
            obj.gameObject.SetActive(true);

            return obj;
        }

        protected Vector2 FindNextAvailableSpot()
        {
            Vector2 result = Vector2.zero;
            result = obstacleHandler.GetFreeSpace(prefab.transform.localScale);
            Debug.Log($"{GetType()}: Randomized point {result}");
            return result;
        }

        protected void AddToDespawned(BaseObject obj)
        {
            obj.gameObject.SetActive(false);
            despawned.Add(obj);
        }

        protected abstract void OnDespawn(BaseObject obj);
    }
}
