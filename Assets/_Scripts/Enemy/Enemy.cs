using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMahgeddon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private Rigidbody2D rb;

        private Transform target;
        private bool hasLanded = false;
        private bool isFalling = true;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Initialize(Transform targetTransform, float fallDelay)
        {
            target = targetTransform;
            StartCoroutine(WaitAndStartMovement(fallDelay));
        }

        private IEnumerator WaitAndStartMovement(float fallDelay)
        {
            yield return new WaitForSeconds(fallDelay);

            // Once the fall delay is over, start moving
            isFalling = false;
            //rb.isKinematic = false;
            StartMovement();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision with: " + collision.gameObject.name);

            if (isFalling && collision.gameObject.CompareTag("Ground"))
            {
                isFalling = false;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                StartMovement();
            }
        }

        private void StartMovement()
        {
            if (target != null)
            {
                rb.isKinematic = false;
                Vector2 direction = ((Vector2)target.position - rb.position).normalized;
                rb.velocity = direction * speed;
                Debug.Log("Moving towards: " + target.position + " with velocity: " + rb.velocity);
            }
        }
    }
}
