using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject flyingEnemyPrefab; // Prefab for the flying enemy
    [SerializeField] private Transform spawnPoint; // Single spawn point for enemies
    [SerializeField] private float spawnInterval = 3f; // Time between enemy spawns
    [SerializeField] private int maxEnemies = 5; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;

    private static SpawnManager instance;
    public static SpawnManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
            // Instantiate the enemy at the spawn point
            GameObject enemy = Instantiate(flyingEnemyPrefab, spawnPoint.position, Quaternion.identity);
            FlyingEnemy flyingEnemy = enemy.GetComponent<FlyingEnemy>();

            if (flyingEnemy != null)
            {
                // Set waypoints if needed; Example of setting waypoints (use your own logic here)
                // Assuming waypoints are stored as Vector3 positions
                flyingEnemy.SetWaypoints(new Vector3[]
                {
                    new Vector3(6.57f, 0.5f, 0),
                    new Vector3(3.91f, 1.84f, 0),
                    new Vector3(1.6f, 0.72f, 0)
                });
            }

            // Increase enemy count
            currentEnemyCount++;

            // Wait before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Call this method when an enemy is destroyed to keep the count correct
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
