using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button volumeButton;
    [SerializeField] private GameObject volumeBox;
    private bool boxActive;

    private void Start()
    {
        backButton.onClick.AddListener(BackToLobby);
        restartButton.onClick.AddListener(RestartLevel);
        resumeButton.onClick.AddListener(ResumeLevel);
        volumeButton.onClick.AddListener(VolumeChange);
        boxActive = true;
    }

    private void VolumeChange()
    {
        volumeBox.SetActive(boxActive);
        if(boxActive )
        {
            boxActive = false;
        }
        else
        {
            boxActive = true;
        }
    }

    private void ResumeLevel()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    private void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackToLobby()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
