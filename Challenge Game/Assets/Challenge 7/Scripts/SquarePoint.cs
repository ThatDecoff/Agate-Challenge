using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge5;

namespace Game.Challenge7
{
    public class SquarePoint : MonoBehaviour
    {
        public bool IsRespawn;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                if (IsRespawn)
                {
                    if (GameManager.Instance != null && GameManager.Instance.SquareSpawner != null)
                    {
                        GameManager.Instance.SquareSpawner.SpawnNext(gameObject);
                    }
                }
                else
                {
                    gameObject.SetActive(false);
                }

                if (GameManager.Instance != null && GameManager.Instance.pointHandler != null)
                {
                    GameManager.Instance.pointHandler.AddPoint(1);
                }
            }
        }
    }
}
