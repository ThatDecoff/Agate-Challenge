using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge5;

namespace Game.Challenge6
{
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public Transform parent;
        public int ObjectCount;
        public int Offset;

        private ObjectPool<GameObject> pool;
        private int RandomObjCount;
        private int CurrentObjCount;

        private void Awake()
        {
            pool = new ObjectPool<GameObject>(() => { return CreatePrefab(); });
        }

        private void Start()
        {
            RandomObjCount = Random.Range(ObjectCount - Offset, ObjectCount + Offset);
            Debug.Log($"{GetType()}: Randomized {RandomObjCount}");
            for(int i = 0; i < RandomObjCount; i++)
            {
                GameObject obj = SpawnObject();
                if(GameManager.Instance != null && GameManager.Instance.obstacleHandler != null)
                {
                    GameManager.Instance.obstacleHandler.AddObject(obj);
                }
            }
        }

        public void SpawnNext(GameObject obj)
        {
            pool.FreeObject(obj);
            obj.SetActive(false);

            Invoke("SpawnObject", 3);
        }

        private GameObject SpawnObject()
        {
            GameObject obj = pool.GetObject();
            obj.transform.position = FindNextAvailableSpot();
            obj.SetActive(true);

            return obj;
        }

        private Vector2 FindNextAvailableSpot()
        {
            Vector2 result = Vector2.zero;
            if (GameManager.Instance != null && GameManager.Instance.obstacleHandler != null)
            {
                result = GameManager.Instance.obstacleHandler.GetFreeSpace(prefab.transform.localScale);
            }
            return result;
        }

        private GameObject CreatePrefab()
        {
            return Instantiate(prefab, parent);
        }
    }
}
