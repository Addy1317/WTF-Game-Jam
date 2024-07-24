using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float updatePoints = 2f;
    [SerializeField] private float damage = 1f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        FlyingEnemy enemy1 = collision.gameObject.GetComponent<FlyingEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage, updatePoints);
            Destroy(this.gameObject);
        }
        else if (enemy1 != null)
        {
            enemy1.TakeDamage(damage, updatePoints);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
