﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge4;

namespace Game.Challenge5
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;

        [Header("Player")]
        public BallMovementInput playerMovement;
        public WorldRectangle WorldRect;

        private void Awake()
        {
            Instance = this;
        }
    }
}