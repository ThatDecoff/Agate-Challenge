using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge9
{
    public class BallMovementInput : MonoBehaviour
    {
        [Header("Attributes")]
        public float Speed = 5f;

        [Header("Dependency")]
        public WorldRectangle worldRect;
        public ObstacleHandler obstacleHandler;
        public GameOverHandler gameOverHandler;

        private Rigidbody2D rb2d;

        private Vector2 target;
        private bool isMoving;

        private void Start()
        {
            //obstacleHandler.AddObject(gameObject);

            rb2d = GetComponent<Rigidbody2D>();

            target = transform.position;
            isMoving = false;
        }

        private void Update()
        {
            GetClickInput();

            MoveObject();
        }

        public void MoveToPoint(Vector2 point)
        {
            target = point;
            isMoving = true;
        }

        private void MoveObject()
        {
            if ((Vector2)transform.position == target)
            {
                isMoving = false;
            }

            if (isMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * Speed);
                if(worldRect != null)
                {
                    bool hasReachedMoveLimit = !worldRect.CheckIsInside(transform.position, transform.localScale/2);
                    if (hasReachedMoveLimit)
                    {
                        Vector3 newPos = worldRect.ClampToWorld(transform.position);
                        transform.position = newPos;
                        isMoving = false;
                    }
                }
            }
        }

        private void GetClickInput()
        {

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log($"{GetType()}: Clicked 0 at {Input.mousePosition}");
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                MoveToPoint(MousePos);
            }
        }
    }
}