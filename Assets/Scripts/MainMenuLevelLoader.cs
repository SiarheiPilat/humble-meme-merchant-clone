using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLevelLoader : MonoBehaviour
{
    public Button ContinueButton;

    void Start()
    {
        if(PlayerPrefs.GetInt("LatestLevel") > 0)
        {
            ContinueButton.interactable = true;
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLatestLevel()
    {
        int LatestLevel = PlayerPrefs.GetInt("LatestLevel");
        SceneManager.LoadScene(LatestLevel);
    }
}
