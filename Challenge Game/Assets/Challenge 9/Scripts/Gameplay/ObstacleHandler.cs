using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class ObstacleHandler : MonoBehaviour
    {
        public WorldRectangle worldRect;

        public List<GameObject> AssignedObjects;

        private List<GameObject> obstacles = new List<GameObject>();

        private Vector2 Min = Vector2.zero;
        private Vector2 Max = Vector2.zero;

        private void Awake()
        {
            foreach (GameObject obj in AssignedObjects)
            {
                AddObject(obj);
            }
        }

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

                Vector3 ObjPosition = obj.transform.position;
                Vector3 ObjScale = obj.transform.localScale;

                if(obj.tag == "Player")
                {
                    ObjScale = new Vector2(3, 3);
                }

                Vector3 ObjMin = ObjPosition - ObjScale;
                Vector3 ObjMax = ObjPosition + ObjScale;

                bool TopLeftInside = IsPointInsideRect(TopLeft, ObjMin, ObjMax);
                bool TopRightInside = IsPointInsideRect(TopRight, ObjMin, ObjMax);
                bool BottomLeftInside = IsPointInsideRect(BottomLeft, ObjMin, ObjMax);
                bool BottomRightInside = IsPointInsideRect(BottomRight, ObjMin, ObjMax);

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
