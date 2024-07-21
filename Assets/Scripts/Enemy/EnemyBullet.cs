using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int damage = 1;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerController>())
        {

            TowerController.Instance.TakeDamage(damage);
            Destroy(gameObject); // Destroy the bullet on impact
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
}
