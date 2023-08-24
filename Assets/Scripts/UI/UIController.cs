using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button ffButton;

    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private TextMeshProUGUI ballCounter;
    [SerializeField] private ShooterController shooterController;

    private void Start()
    {
        pauseButton.onClick.AddListener(ShowPauseMenu);
        ffButton.onClick.AddListener(FastForward);
    }
    private void Update()
    {
        ChangeBallCounter();
    }
    private void FastForward()
    {
        Time.timeScale = 1.5f;
    }

    private void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
    }

    private void ChangeBallCounter()
    {
        int count = shooterController.GetCurrentBalls();
        ballCounter.text = "Balls : " + count.ToString();
    }
}
