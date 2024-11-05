using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletManager manager;
    Rigidbody rb;

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
        rb.velocity = velocity;
    }

    private void ReturnToPool()
    {
        manager.ReturnToPool(this);
    }
}
