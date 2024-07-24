using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private BulletController bullet;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float shootDelay;

    private float timeStamp;

    private void OnEnable()
    {
        timeStamp = Time.time + shootDelay; // Ensure firing starts after enabling
        StartCoroutine(DisableTurret(10)); // Start the coroutine to disable the turret
    }

    private void Update()
    {
        if (Time.time > timeStamp)
        {
            FireBullet();
            timeStamp = Time.time + shootDelay;
        }
    }

    private void FireBullet()
    {
        if (bullet == null)
        {
            return;
        }

        BulletController newBullet = Instantiate(bullet, firePosition.position, firePosition.rotation);
        newBullet.transform.Rotate(0, 0, 90);
        AudioManager.Instance.PlaySFX(AudioName.BulletSound);
    }

    private IEnumerator DisableTurret(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
        TowerController.Instance.OnTurretDisabled(); // Notify TowerController when the turret is disabled
    }
}
