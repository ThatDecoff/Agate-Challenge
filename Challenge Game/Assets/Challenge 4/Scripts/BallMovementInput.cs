using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge4
{
    public class BallMovementInput : MonoBehaviour
    {
        [Header("Attributes")]
        public float Speed = 5f;
        public bool isKeyboardInput;

        private Rigidbody2D rb2d;

        private Vector2 target;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            target = transform.position;
        }

        private void Update()
        {
            if (isKeyboardInput)
            {
                GetInput();
            }

            if((Vector2)transform.position != target)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * Speed);
            }
        }

        public void MoveToPoint(Vector2 point)
        {
            target = point;
        }

        private void GetInput()
        {
            Vector2 direction = Vector2.zero;

            direction.x += Input.GetAxisRaw("Horizontal");
            direction.y += Input.GetAxisRaw("Vertical");

            MoveToPoint((Vector2)transform.position + direction * Speed);
        }
    }
}