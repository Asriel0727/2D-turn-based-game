using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public TreeMonster treeMonster1;
    public TreeMonster treeMonster2;
    public TreeMonster treeMonster3;
    public PlayerValue playerValue;

    public int hart;
    public int attack;
    public int special;
    public int coin;
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
            hart = playerValue.hart;
            attack = playerValue.attack;
            special = playerValue.special;
            coin = playerValue.coin;

            PlayerPrefs.SetInt("InitHart", hart);
            PlayerPrefs.SetInt("InitAttack", attack);
            PlayerPrefs.SetInt("InitSpecial", special);
            PlayerPrefs.SetInt("InitCoin", coin);
            PlayerPrefs.Save();
            EndBattle();
        }
    }
}
