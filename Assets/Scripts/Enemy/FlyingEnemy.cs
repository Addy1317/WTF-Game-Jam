using System.Collections;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private EnemyBullet bullet;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float shootingInterval = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private float health = 2f;

    [SerializeField] private Vector3[] waypoints; // Waypoints for the enemy to follow

    private Rigidbody2D rb;
    private int currentWaypointIndex = 0;
    private bool isShooting = false;
    private bool hasReachedFinalWaypoint = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasReachedFinalWaypoint)
        {
            MoveTowardsWaypoint();
        }
        else if (!isShooting)
        {
            isShooting = true;
            animator.SetBool("IsAttacking", true);
            StartCoroutine(ShootBullets());
        }
    }

    public void TakeDamage(float damage, float updatePoints)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            TowerController.Instance.UpdateBar(updatePoints);
            SpawnManager.Instance.OnEnemyDestroyed(); // Notify the spawn manager
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Vector2 direction = ((Vector2)waypoints[currentWaypointIndex] - rb.position).normalized;
            float distance = Vector2.Distance(waypoints[currentWaypointIndex], rb.position);

            if (distance > 0.1f) // Check if the enemy has reached the waypoint
            {
                animator.SetBool("IsFlying", true);
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
                animator.SetBool("IsFlying", false);
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    hasReachedFinalWaypoint = true;
                }
                
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

    public void SetWaypoints(Vector3[] newWaypoints)
    {
        waypoints = newWaypoints;
    }

    private void TriggerFlyingAnim()
    {
        animator.SetBool("IsFlying", true);
    }
}
