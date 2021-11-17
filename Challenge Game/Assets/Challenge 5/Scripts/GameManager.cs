using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge4;
using Game.Challenge6;

namespace Game.Challenge5
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;

        [Header("Player")]
        public BallMovementInput playerMovement;
        public WorldRectangle WorldRect;

        [Header("Items")]
        public ObjectSpawner SquareSpawner;
        public ObstacleHandler obstacleHandler;

        private void Awake()
        {
            Instance = this;
        }
    }
}
