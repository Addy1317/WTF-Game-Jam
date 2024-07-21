using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    [SerializeField] private float health = 50f;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image updateBar;
    [SerializeField] private TurretController turretController;

    private float updatePoint;
    private bool isTurretActive;

    private static TowerController instance;
    public static TowerController Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(updatePoint == 50)
        {
            GetTurret();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            // Handle tower destruction
            Debug.Log("Tower is destroyed!");
            Destroy(gameObject);
        }
    }

    public void UpdateBar(float points)
    {
        if(!isTurretActive)
        {
            updatePoint += points;
            updatePoint = Mathf.Clamp(updatePoint, 0, 50);
            updateBar.fillAmount = updatePoint / health;
        }
    }

    public void GetTurret()
    {
        isTurretActive = true;
        turretController.gameObject.SetActive(true);
        updatePoint = 0;
        updateBar.fillAmount = updatePoint / 50f;
    }
}
