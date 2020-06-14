using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager instance; // singleton pattern
    public Transform Player;
    public AudioSource AudioSource;

    public GameObject PauseMenu, SoundButton, LeftButton, RightButton, JumpButton, PauseButton, ScoreLabel, GameOverMenu;

    public void OnPause()
    {
        Time.timeScale = 0.0f;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        SoundButton.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        SoundButton.SetActive(false);
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
    }

    public void ToggleSound()
    {
        AudioSource.mute = AudioSource.mute == true ? false : true; // ternary operator
    }

    public void ExtraJump()
    {

    }

    public void KillPlayer()
    {
        Player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
