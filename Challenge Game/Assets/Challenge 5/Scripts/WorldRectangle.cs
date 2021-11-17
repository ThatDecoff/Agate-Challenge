﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge5
{
    public class WorldRectangle : MonoBehaviour
    {
        [Header("Dimension")]
        public Vector2 Min;
        public Vector2 Max;

        public bool CheckIsInside(Vector2 position, Vector2 offset)
        {
            bool xIsInside = (Min.x <= position.x - offset.x && position.x + offset.x <= Max.x);
            bool yIsInside = (Min.y <= position.y - offset.y && position.y + offset.y <= Max.y);
            //Debug.Log($"{GetType()}: {xIsInside};{yIsInside};{(xIsInside && yIsInside)}");
            return (xIsInside && yIsInside);
        }

        public Vector3 ClampToWorld(Vector3 position)
        {
            Vector3 result = Vector3.zero;

            result.x = Mathf.Clamp(position.x, Min.x, Max.x);
            result.y = Mathf.Clamp(position.y, Min.y, Max.y);

            return result;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Min, 0.1f);
            Gizmos.DrawSphere(Max, 0.1f);
            Gizmos.DrawLine(Min, Max);
        }
    }
}
