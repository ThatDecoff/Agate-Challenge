using UnityEngine;
using System;

namespace Game.Challenge9
{
    public class BaseObject : MonoBehaviour
    {
        public float Speed = 5f;

        public event Action<BaseObject> OnDespawn = delegate { };

        private bool Interacted;

        private void OnEnable()
        {
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

            Vector2 direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            direction.Normalize();

            rb2d.velocity = direction * Speed;

            Interacted = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player" && !Interacted)
            {
                Interacted = true;
                OnPlayerEnter(collision.gameObject);
                OnDespawn.Invoke(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Collectable")
            {
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            }
        }

        protected virtual void OnPlayerEnter(GameObject player)
        {
            return;
        }
    }
}
