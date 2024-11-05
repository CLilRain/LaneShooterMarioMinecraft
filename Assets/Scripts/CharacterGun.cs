using System.Collections;
using UnityEngine;

public class CharacterGun : MonoBehaviour
{
    public BulletManager bulletManager;

    public Transform muzzle;

    [SerializeField]
    float initialShootInterval = 0.5f;

    [SerializeField]
    float initialShootVelocity = 10f;

    Coroutine shootCoroutine;

    float currentShootInterval;
    float currentShootVelocity;

    void Awake()
    {
        currentShootInterval = initialShootInterval;
        currentShootVelocity = initialShootVelocity;
        StartShooting();
    }


    void StartShooting()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }


        shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        var wait = new WaitForSeconds(currentShootInterval);

        while (true)
        {
            yield return wait;

            var bullet = bulletManager.GetBullet(startPosition: muzzle.position);
            bullet.Shoot(muzzle.forward * currentShootVelocity);
        }
    }
}