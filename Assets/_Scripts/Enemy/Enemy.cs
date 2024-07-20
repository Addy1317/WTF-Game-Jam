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
            isFalling = false;
            rb.isKinematic = false;
        }

        private void Update()
        {
            if (!isFalling && target != null)
            {
                MoveTowardsTarget();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isFalling && collision.gameObject.CompareTag("Ground"))
            {
                isFalling = false;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                FreezeYPosition();
            }
        }

        private void MoveTowardsTarget()
        {
            Vector2 direction = ((Vector2)target.position - rb.position).normalized;
            rb.velocity = direction * speed;
        }

        private void FreezeYPosition()
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
