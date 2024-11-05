using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet prefab;

    const int StartPoolSize = 100;
    const int MaxPoolSize = 1000;

    private List<Bullet> pool;

    private int spawnedAmount;
    private int currentIndex = -1;

    void Start()
    {
        pool = new List<Bullet>(MaxPoolSize);

        for (int i = 0; i < StartPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(prefab, transform);
        bullet.Init(this);
        bullet.gameObject.SetActive(false);
        pool.Add(bullet);
        spawnedAmount++;
    }

    public Bullet GetBullet()
    {
        if (pool.Count > 0 && spawnedAmount < MaxPoolSize)
        {
            CreateBullet();
        }

        var bullet = pool[0];
        pool.RemoveAt(0);

        return bullet;
    }

    private void IncrementIndex()
    {
        currentIndex++;
        if (currentIndex >= pool.Count)
        {
            currentIndex = 0;
        }
    }

    public void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Add(bullet);
    }
}
