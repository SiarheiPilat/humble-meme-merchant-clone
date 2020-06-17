using UnityEngine;

public class BossAI : EnemyAI
{
    public float BulletFireRate, StartsFiringAfter;

    // object pooling
    private int index;
    public GameObject[] BulletsPool;

    void Start()
    {
        OnStart();
        InvokeRepeating("FireBullet", StartsFiringAfter, BulletFireRate);
    }

    void Update()
    {
        OnUpdate();
    }

    void FireBullet()
    {
        BulletsPool[index].transform.position = Head.position;
        BulletsPool[index].SetActive(true);
        if(m_currentWaypoint.position.x < transform.position.x)
        {
            // left; spawn bullet and send its direction to 'left'
            BulletsPool[index].GetComponent<Bullet>().Direction = Vector3.left;
        }
        else
        {
            // right; spawn bullet and send its direction to 'right'
            BulletsPool[index].GetComponent<Bullet>().Direction = Vector3.right;
        }
        index++;
        if (index == BulletsPool.Length) index = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision();
    }
}
