using System.Collections;
using System.Collections.Generic;
using TreeMahgeddon.Enemy;
using UnityEngine;

namespace TreeMahgeddon
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyController; 
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
                enemyController.SpawnEnemy();
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
