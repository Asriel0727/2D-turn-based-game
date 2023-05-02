using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForDebug : MonoBehaviour
{
    public void BackLevel()
    {
        // �O�sĲ�o������m��PlayerPrefs
        PlayerPrefs.SetFloat("LastTriggerPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastTriggerPosY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameObject enemy;

    private void Start()
    {
        enemy.SetActive(true);
    }

    public void EndBattle()
    {
        enemy.SetActive(false);
        SceneManager.LoadScene(1);
    }

}
