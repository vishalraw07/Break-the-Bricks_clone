using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadLevel : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] public string levelName;

    private void Start()
    {
        button.onClick.AddListener(TryToLoadLevel);
    }

    private void TryToLoadLevel()
    {
        LevelStatus status = LevelManager.Instance.GetLevelStatus(levelName);

        switch(status)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
