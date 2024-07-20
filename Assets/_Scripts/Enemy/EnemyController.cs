using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMahgeddon.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint; 
        [SerializeField] private Transform tower; 
        [SerializeField] private GameObject[] enemyPrefabs; 
        [SerializeField] private float spawnDelay = 3f; 
        [SerializeField] private float enemyFallDelay = 2f; 

        private void Start()
        {
            // Start the spawning process
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private void SpawnEnemy()
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[index];

            // Use the fixed spawn point for the spawn position
            Vector2 spawnPosition = spawnPoint.position;

            // Instantiate the enemy at the spawn position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Set up the enemy to start moving towards the tower after a delay
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.Initialize(tower, enemyFallDelay);
            }
        }
    }
}