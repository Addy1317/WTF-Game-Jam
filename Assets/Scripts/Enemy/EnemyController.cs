using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private EnemyBullet bullet;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float shootingInterval = 1f;
    [SerializeField] private Animator animator;

    [SerializeField] private float health = 2f;

    private Rigidbody2D rb;
    private Transform target;
    private bool isShooting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Transform targetTransform, float fallDelay)
    {
        target = targetTransform;
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    public void TakeDamage(float damage, float updatePoints)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(this.gameObject);
            TowerController.Instance.UpdateBar(updatePoints);
        }
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        float distance = Vector2.Distance(target.position, rb.position);

        if (distance > 1) // Check if the enemy has reached the target
        {
            animator.SetBool("IsWalking", true);
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("IsWalking", false);

            if (!isShooting)
            {
                isShooting = true;
                animator.SetBool("IsAttacking", true);
                StartCoroutine(ShootBullets());
            }
        }
    }

    private void FreezeYPosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            EnemyBullet newBullet = Instantiate(bullet, firePosition.position, firePosition.rotation);
            newBullet.transform.Rotate(0, 0, -90);
            AudioManager.Instance.PlaySFX(AudioName.BulletSound);
            yield return new WaitForSeconds(shootingInterval);
        }
    }
}

