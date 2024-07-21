using System.Collections;
using System.Collections.Generic;
using TreeMahgeddon.Tower;
using UnityEngine;

namespace TreeMahgeddon.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifetime = 5f;
        [SerializeField] private int damage = 1;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }

        private void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Tower"))
            {
                TowerController tower = collision.GetComponent<TowerController>();
                if (tower != null)
                {
                    tower.TakeDamage(damage);
                }
                Destroy(gameObject); // Destroy the bullet on impact
            }
            
            else if (collision.gameObject.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }
}
