using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float maxPositiveRotation, maxNegativeRotation;
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootDelay;

    private float timeStamp;

    void Update()
    {
        WeaponRotation();

        if (Input.GetMouseButtonDown(0) && Time.time > timeStamp)
        {
            FireBullet();
            timeStamp = Time.time + shootDelay;
        }
    }

    private void WeaponRotation()
    {
        // Get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate angle (in degrees)
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        // Clamp the angle to -90° to 90°
        angle = Mathf.Clamp(angle, maxNegativeRotation, maxPositiveRotation);

        // Apply rotation
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void FireBullet()
    {
        if (bullet == null)
        {
            Debug.Log("Bullet is null");
            return;
        }

        // Instantiate the bullet and set its rotation
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.transform.Rotate(0, 0, 90); // Adjust this rotation as needed
        Debug.Log("BulletFired");
    }
}
