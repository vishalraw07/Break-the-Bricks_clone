using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreenController : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(BackToLobby);
    }

    private void BackToLobby()
    {
        gameObject.SetActive(false);
    }
}
