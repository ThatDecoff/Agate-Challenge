using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge5;

namespace Game.Challenge7
{
    public class SquarePoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                if(GameManager.Instance != null && GameManager.Instance.SquareSpawner != null)
                {
                    GameManager.Instance.SquareSpawner.SpawnNext(gameObject);
                }
                if (GameManager.Instance != null && GameManager.Instance.pointHandler != null)
                {
                    GameManager.Instance.pointHandler.AddPoint(1);
                }
            }
        }
    }
}
