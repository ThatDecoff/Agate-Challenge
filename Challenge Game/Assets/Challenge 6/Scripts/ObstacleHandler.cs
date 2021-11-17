using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge5;

namespace Game.Challenge6
{
    public class ObstacleHandler : MonoBehaviour
    {
        private List<GameObject> obstacles = new List<GameObject>();

        private Vector2 Min = Vector2.zero;
        private Vector2 Max = Vector2.zero;

        private void Start()
        {
            if(GameManager.Instance != null && GameManager.Instance.WorldRect != null)
            {
                Min = GameManager.Instance.WorldRect.Min;
                Max = GameManager.Instance.WorldRect.Max;
            }

            if(GameManager.Instance != null && GameManager.Instance.playerMovement != null)
            {
                obstacles.Add(GameManager.Instance.playerMovement.gameObject);
            }
        }

        public void AddObject(GameObject obj)
        {
            obstacles.Add(obj);
        }

        public Vector2 GetFreeSpace(Vector2 offset)
        {
            Vector2 randomPos = new Vector2(Random.Range(Min.x, Max.x), Random.Range(Min.y, Max.y));
            while(!IsFree(randomPos, offset))
            {
                randomPos = new Vector2(Random.Range(Min.x, Max.x), Random.Range(Min.y, Max.y));
            }
            return randomPos;
        }

        private bool IsFree(Vector2 position, Vector2 offset)
        {
            if(GameManager.Instance != null && GameManager.Instance.WorldRect != null)
            {
                bool IsInsideBorder = GameManager.Instance.WorldRect.CheckIsInside(position, offset);
                if (!IsInsideBorder)
                {
                    return false;
                }
            }

            Vector2 TopLeft = new Vector2(position.x - offset.x / 2, position.y + offset.y/2);
            Vector2 TopRight = position + offset / 2;

            Vector2 BottomLeft = position - offset / 2;
            Vector2 BottomRight = new Vector2(position.x + offset.x / 2, position.y - offset.y / 2);

            foreach (GameObject obj in obstacles)
            {
                if (!obj.activeSelf)
                {
                    continue;
                }

                bool TopLeftInside = IsPointInsideRect(TopLeft, obj.transform.position - obj.transform.localScale / 2, obj.transform.position + obj.transform.localScale / 2);
                bool TopRightInside = IsPointInsideRect(TopRight, obj.transform.position - obj.transform.localScale / 2, obj.transform.position + obj.transform.localScale / 2);
                bool BottomLeftInside = IsPointInsideRect(BottomLeft, obj.transform.position - obj.transform.localScale / 2, obj.transform.position + obj.transform.localScale / 2);
                bool BottomRightInside = IsPointInsideRect(BottomRight, obj.transform.position - obj.transform.localScale / 2, obj.transform.position + obj.transform.localScale / 2);

                if(TopLeftInside || TopRightInside || BottomLeftInside || BottomRightInside)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsPointInsideRect(Vector2 point, Vector2 Min, Vector2 Max)
        {
            bool xIsInside = (Min.x <= point.x && point.x <= Max.x);
            bool yIsInside = (Min.y <= point.y && point.y <= Max.y);

            return (xIsInside && yIsInside);
        }
    }
}
