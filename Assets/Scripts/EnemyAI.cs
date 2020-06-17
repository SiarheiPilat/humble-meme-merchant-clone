using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform WaypointA, WaypointB;
    public Transform Head;
    public float Speed, ReachThreshold;
    public AudioClip DeathSound;

    protected Transform m_currentWaypoint;
    public SpriteRenderer SpriteRenderer;
    public Animator Animator;

    protected bool m_isShrinking;
    public Vector3 ShrinkSize;
    public float ScaleLimit;

    protected void MoveTo(Transform Waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoint.position, Time.deltaTime * Speed);
        if(Vector3.Distance(transform.position, Waypoint.position) < ReachThreshold)
        {
            // turn around
            m_currentWaypoint = m_currentWaypoint == WaypointA ? WaypointB : WaypointA;
            SpriteRenderer.flipX = SpriteRenderer.flipX == true ? false : true;
        }
    }

    void Start()
    {
        OnStart();
    }

    protected void OnStart()
    {
        m_currentWaypoint = WaypointA;
    }

    void Update()
    {
        OnUpdate();
    }

    protected void OnUpdate()
    {
        MoveTo(m_currentWaypoint);

        if (m_isShrinking)
        {
            // shrink logic
            transform.localScale -= ShrinkSize;
            if (transform.localScale.y < ScaleLimit)
            {
                DestroyEnemy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision();
    }

    protected void CheckCollision()
    {
        if (Manager.instance.Player.position.y > Head.position.y)
        {
            // kill enemy
            KillEnemy();
            Manager.instance.AudioSource.PlayOneShot(DeathSound);
            // extra jump
            Manager.instance.ExtraJump();
        }
        else
        {
            // kill player
            Manager.instance.KillPlayer();
        }
    }

    protected void KillEnemy()
    {
        Manager.instance.AudioSource.PlayOneShot(DeathSound);
        m_isShrinking = true;
    }

    public void DestroyEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
