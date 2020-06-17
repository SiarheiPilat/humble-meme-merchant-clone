using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void OnEnable()
    {
        ScoreText.text = Manager.instance.Score.ToString();
    }
}
