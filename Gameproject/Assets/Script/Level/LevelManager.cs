using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelInstance;
    public int currentLevel;

    private void Start()
    {
        if (PlayerPrefs.HasKey("playerPrefsKey"))
        {
            currentLevel = PlayerPrefs.GetInt("playerPrefsKey");
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("playerPrefsKey", 1);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        if (levelInstance == null)
        {
            levelInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("playerPrefsKey", currentLevel);
        PlayerPrefs.Save();
    }
}
