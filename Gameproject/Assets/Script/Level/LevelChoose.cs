using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour
{
    public Button[] levelButtons;
    public Text errorText;

    private void Start()
    {
        int unlockedLevels = LevelManager.levelInstance.currentLevel;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevels)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void SelectLevel(int levelIndex)
    {
        if(levelIndex == 1)
        {
            string levelName = "Level" + levelIndex;
            LevelManager.levelInstance.LoadLevel(levelName);
        }
        else
        {
            errorText.gameObject.SetActive(true);
            Invoke("ErrorTextClose", 3f);
        }
    }

    public void ErrorTextClose()
    {
        errorText.gameObject.SetActive(false);
    }
}
