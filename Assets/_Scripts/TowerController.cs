using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMahgeddon.Tower
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] private int health = 50;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                // Handle tower destruction
                Debug.Log("Tower is destroyed!");
                Destroy(gameObject);
            }
        }
    }
}
