using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TallMonsterBattleManager : MonoBehaviour
{
    public TallMonster tallMonster1;
    public PlayerValue playerValue;

    public int hart;
    public int attack;
    public int special;
    public int coin;
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
