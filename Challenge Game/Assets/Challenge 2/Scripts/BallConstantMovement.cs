using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Challenge2
{
    public class BallConstantMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            SetMovement();
        }

        private void SetMovement()
        {
            float speed = Random.Range(100f, 500f);
            Vector2 force = new Vector2(Random.value, Random.value);

            rb2d.AddForce(force * speed);
        }
    }
}
