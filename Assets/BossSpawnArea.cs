using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnArea : MonoBehaviour
{
    public GameObject Boss;

    void OnTriggerEnter2D(Collider2D col)
    {
        Boss.SetActive(true);
        Destroy(gameObject);
    }
}
