using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private GameObject blocker;

    private void Start()
    {
        backButton.onClick.AddListener(BackToLobby);
        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(NextLevel);
        blocker.SetActive(true);
    }

    private void NextLevel()
    {
        LevelManager.Instance.SetCurrentLevelComplete();
        Debug.Log("Build count: " + SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % (SceneManager.sceneCountInBuildSettings));
        blocker.SetActive(false);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        blocker.SetActive(false);
    }

    private void BackToLobby()
    {
        SceneManager.LoadScene(0);
        blocker.SetActive(false);
    }
}
