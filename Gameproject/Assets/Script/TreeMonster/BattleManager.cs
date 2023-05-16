using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public TreeMonster treeMonster1;
    public TreeMonster treeMonster2;
    public TreeMonster treeMonster3;
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
        if(treeMonster1.isdead == true && treeMonster2.isdead == true && treeMonster3.isdead == true)
        {
            EndBattle();
        }
    }
}
