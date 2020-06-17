using UnityEngine;

public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Manager.instance.ShowLevelEndMenu();
    }
}
