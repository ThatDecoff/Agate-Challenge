using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Challenge5;

namespace Game.Challenge4
{
    public class BallMovementInput : MonoBehaviour
    {
        [Header("Attributes")]
        public float Speed = 5f;
        public bool isKeyboardInput;
        public bool isClickInput;

        //[Header("Component")]

        private Rigidbody2D rb2d;

        private Vector2 target;
        private bool isMoving;

        private WorldRectangle worldRect;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            if (GameManager.Instance != null)
            {
                worldRect = GameManager.Instance.WorldRect;
            }

            target = transform.position;
            isMoving = false;
        }

        private void Update()
        {
            if (isKeyboardInput)
            {
                GetInput();
            }

            if (isClickInput)
            {
                GetClickInput();
            }

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

        private void GetInput()
        {
            Vector2 direction = Vector2.zero;

            direction.x += Input.GetAxisRaw("Horizontal");
            direction.y += Input.GetAxisRaw("Vertical");
            direction.Normalize();

            if(direction != Vector2.zero)
            {
                MoveToPoint((Vector2)transform.position + direction * Time.deltaTime * Speed);
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