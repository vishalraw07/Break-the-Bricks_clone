using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] private Levels[] levels;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SoundManager.Instance.PlayBG(SoundType.LobbyMusic);

        if (GetLevelStatus(levels[0].name) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0].name, LevelStatus.Unlocked);
        }

        for(int i = 1; i < levels.Length; i++) {
            SetLevelStatus(levels[i].name, LevelStatus.Locked);
        }      
    }

    private void SetLevelStatus(string level, LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);
    }

    public LevelStatus GetLevelStatus(string level1)
    {
        LevelStatus status = (LevelStatus)PlayerPrefs.GetInt(level1);
        return status;
    }
    
    public void SetCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);

        if(!(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings))
            SetLevelStatus(GetNameFromIndex(SceneManager.GetActiveScene().buildIndex + 1), LevelStatus.Unlocked);
    }

    private string GetNameFromIndex(int index)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    public int GetNumberOfBricks(int level)
    {
        return levels[level - 1].numberOfBricks;
    }

    [Serializable]
    public class Levels
    {
        public string name;
        public int numberOfBricks;
    }
}
