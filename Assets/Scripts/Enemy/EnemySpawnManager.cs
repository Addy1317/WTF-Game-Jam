using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform reachPoint;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float enemyFallDelay = 2f;
    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private float spawnRate = 2f;

    private int enemiesSpawned = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < maxEnemies)
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[index];

        Vector2 spawnPosition = spawnPoint.position;

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyController enemyComponent = enemy.GetComponent<EnemyController>();

        if (enemyComponent != null)
        {
            enemyComponent.Initialize(reachPoint, enemyFallDelay);
        }
        else
        {
            Debug.LogWarning("Enemy prefab does not have an EnemyController component.");
        }
    }
}

