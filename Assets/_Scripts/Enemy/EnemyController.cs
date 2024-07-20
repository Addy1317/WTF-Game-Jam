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

            Vector2 spawnPosition = spawnPoint.position;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.Initialize(tower, enemyFallDelay);
            }
        }
    }
}