using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class ObstacleHandler : MonoBehaviour
    {
        public WorldRectangle worldRect;

        private List<GameObject> obstacles = new List<GameObject>();

        private Vector2 Min = Vector2.zero;
        private Vector2 Max = Vector2.zero;

        private void Start()
        {
            Min = worldRect.Min;
            Max = worldRect.Max;
        }

        public void AddObject(GameObject obj)
        {
            obstacles.Add(obj);
        }

        public Vector2 GetFreeSpace(Vector2 offset)
        {
            Min = worldRect.Min;
            Max = worldRect.Max;

            Vector2 randomPos = new Vector2(Random.Range(Min.x, Max.x), Random.Range(Min.y, Max.y));
            while(!IsFree(randomPos, offset))
            {
                randomPos = new Vector2(Random.Range(Min.x, Max.x), Random.Range(Min.y, Max.y));
            }
            return randomPos;
        }

        private bool IsFree(Vector2 position, Vector2 offset)
        {
            bool IsInsideBorder = worldRect.CheckIsInside(position, offset);
            if (!IsInsideBorder)
            {
                return false;
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

                bool TopLeftInside = IsPointInsideRect(TopLeft, obj.transform.position - obj.transform.localScale, obj.transform.position + obj.transform.localScale);
                bool TopRightInside = IsPointInsideRect(TopRight, obj.transform.position - obj.transform.localScale, obj.transform.position + obj.transform.localScale);
                bool BottomLeftInside = IsPointInsideRect(BottomLeft, obj.transform.position - obj.transform.localScale, obj.transform.position + obj.transform.localScale);
                bool BottomRightInside = IsPointInsideRect(BottomRight, obj.transform.position - obj.transform.localScale, obj.transform.position + obj.transform.localScale);

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
