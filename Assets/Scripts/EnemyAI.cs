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
    
    protected void MoveTo(Transform Waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoint.position, Time.deltaTime * Speed);
        if(Vector3.Distance(transform.position, Waypoint.position) < ReachThreshold)
        {
            // turn around
            m_currentWaypoint = m_currentWaypoint == WaypointA ? WaypointB : WaypointA;
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckCollision();
    }

    private void CheckCollision()
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
        Destroy(transform.parent.gameObject);
    }
}
