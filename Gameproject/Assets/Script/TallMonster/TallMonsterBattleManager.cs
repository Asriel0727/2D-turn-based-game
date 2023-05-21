using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TallMonsterBattleManager : MonoBehaviour
{
    public TallMonster tallMonster1;
    public void BackLevel()
    {
        // 保存觸發器的位置到PlayerPrefs
        PlayerPrefs.SetFloat("LastTriggerPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastTriggerPosY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameObject enemy;

    private void Start()
    {
        enemy.SetActive(true);
    }

    private void Update()
    {
        EndCheck();
    }

    private void EndBattle()
    {
        enemy.SetActive(false);
        SceneManager.LoadScene(1);
    }

    private void EndCheck()
    {
        if (tallMonster1.isdead == true)
        {
            EndBattle();
        }
    }
}
