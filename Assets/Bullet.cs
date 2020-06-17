using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed, ResetAfter;
    public Vector3 Direction;

    void OnEnable()
    {
        Invoke("Reset", ResetAfter);
    }

    void Reset()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        Fly(Direction);
    }

    void Fly(Vector3 direction)
    {
        transform.position += direction * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Manager.instance.KillPlayer();
    }
}
