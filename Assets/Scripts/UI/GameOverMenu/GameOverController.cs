using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject blocker;

    private void Start()
    {
        backButton.onClick.AddListener(BackToLobby);
        restartButton.onClick.AddListener(RestartLevel);
        blocker.SetActive(true);
    }
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        blocker.SetActive(false);
    }
    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackToLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
