using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;

    BulletManager manager;
    Rigidbody rb;
    Coroutine selfDestroyCoroutine;

    public void Init(BulletManager manager)
    {
        this.manager = manager;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // check for collision
    }

    public void Shoot(Vector3 velocity)
    {
        rb.linearVelocity = velocity;
        StopSelfDestroyCoroutine();

        selfDestroyCoroutine = StartCoroutine(SelfDestroyCoroutine());
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        ReturnToPool();
    }

    private void StopSelfDestroyCoroutine()
    {
        if (selfDestroyCoroutine != null)
        {
            StopCoroutine(selfDestroyCoroutine);
        }
    }

    private void ReturnToPool()
    {
        StopSelfDestroyCoroutine();
        manager.ReturnToPool(this);
    }
}
