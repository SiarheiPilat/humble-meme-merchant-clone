using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance; // singleton pattern
    public Transform Player;
    public AudioSource AudioSource;

    public GameObject PauseMenu, SoundButton, LeftButton, RightButton, JumpButton, PauseButton, ScoreLabel, GameOverMenu, LevelEndMenu;

    public AudioClip PlayerDeathSound;

    public Player PlayerMovement;

    // handled by UI button (rename to OnPauseButtonPressed!)
    public void OnPauseButtonPressed()
    {
        Pause();
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        SoundButton.SetActive(true);
    }

    // handled by UI button (rename to OnResumeButtonPressed!)
    public void OnResume()
    {
        Resume();
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        SoundButton.SetActive(false);
    }

    public void ShowLevelEndMenu()
    {
        DisablePlayerInput();
        Pause();
        LevelEndMenu.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; UpdateScoreUI();  }
    }

    public TextMeshProUGUI ScoreDisplayText;

    private void UpdateScoreUI()
    {
        ScoreDisplayText.text = score.ToString();
    }

    void Start()
    {
        instance = this;
        Time.timeScale = 1.0f;
        EnablePlayerInput();

        PlayerPrefs.SetInt("LatestLevel", SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleSound()
    {
        AudioSource.mute = AudioSource.mute == true ? false : true; // ternary operator
    }

    public void ExtraJump()
    {
        PlayerMovement.ExtraJump();
    }

    public void KillPlayer()
    {
        Player.gameObject.SetActive(false);
        GameOverMenu.SetActive(true);
        AudioSource.PlayOneShot(PlayerDeathSound);
        DisablePlayerInput();
    }

    void EnablePlayerInput()
    {
        LeftButton.SetActive (true);
        RightButton.SetActive(true);
        JumpButton.SetActive (true);
        ScoreLabel.SetActive (true);
    }

    void DisablePlayerInput()
    {
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        JumpButton.SetActive(false);
        ScoreLabel.SetActive(false);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        int NextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(NextLevelIndex);
    }
}
