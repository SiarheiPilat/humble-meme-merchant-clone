using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform WaypointA, WaypointB;
    public float Speed, ReachThreshold;

    protected Transform m_currentWaypoint;

    protected void MoveTo(Transform Waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoint.position, Time.deltaTime * Speed);
        if (Vector3.Distance(transform.position, Waypoint.position) < ReachThreshold)
        {
            // turn around
            m_currentWaypoint = m_currentWaypoint == WaypointA ? WaypointB : WaypointA;
        }
    }

    void Start()
    {
        m_currentWaypoint = WaypointA;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(gameObject.transform);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.transform.SetParent(null);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        MoveTo(m_currentWaypoint);
    }
}
