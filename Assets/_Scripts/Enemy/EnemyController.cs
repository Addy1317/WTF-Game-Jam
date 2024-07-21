using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMahgeddon.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform reachPoint;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private float enemyFallDelay = 2f;

        internal void SpawnEnemy()
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[index];

            Vector2 spawnPosition = spawnPoint.position;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.Initialize(reachPoint, enemyFallDelay);
            }
            else
            {
                Debug.LogWarning("Enemy prefab does not have an Enemy component.");
            }
        }
    }
}