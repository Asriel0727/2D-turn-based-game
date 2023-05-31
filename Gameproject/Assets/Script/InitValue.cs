using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitValue : MonoBehaviour
{
    public int hart;
    public int attack;
    public int special;
    public int coin;
    public int now;

    public PlayerValue playerValue;
    private void Start()
    {
        playerValue.InitPlayerVelue();
        // 重製玩家位置
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");

        //重製怪物
        PlayerPrefs.SetInt("IsTreePrefabActive", 1);
        PlayerPrefs.SetInt("IsTallPrefabActive", 1);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void SavePlayerData()
    {
        hart = playerValue.inithart;
        attack = playerValue.initattack;
        special = playerValue.initspecial;
        coin = playerValue.initcoin;
        now = 0;

        PlayerPrefs.SetInt("InitHart", hart);
        PlayerPrefs.SetInt("InitAttack", attack);
        PlayerPrefs.SetInt("InitSpecial", special);
        PlayerPrefs.SetInt("InitCoin", coin);
        PlayerPrefs.SetInt("InitNow", now);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }
}
