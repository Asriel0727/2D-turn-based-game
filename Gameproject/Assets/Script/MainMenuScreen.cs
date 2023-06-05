using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public int hart;
    public int attack;
    public int special;
    public int coin;
    public int now;
    public PlayerValue playerValue;

    private void Start()
    {
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");
        PlayerPrefs.SetInt("IsTreePrefabActive",1);
        PlayerPrefs.SetInt("IsTallPrefabActive",1);
        playerValue.InitPlayerVelue();
        playerValue.InitPlayerBagVelue();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {

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
