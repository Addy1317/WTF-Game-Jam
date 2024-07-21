using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float shootDelay;

    private float timeStamp;

    void Update()
    {
        if(Time.time >timeStamp)
        {
            FireBullet();
            timeStamp = Time.time + shootDelay;
        }
    }

    private void FireBullet()
    {
        if(bullet == null)
        {
            return;
        }

        BulletController newBullet = Instantiate(bullet, firePosition.position, firePosition.rotation);
        newBullet.transform.Rotate(0, 0, 90);
        AudioManager.Instance.PlaySFX(AudioName.BulletSound);
    }
}
