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
    public int smallHealPosion;
    public int bigHealPosion;
    public int smallBluePosion;
    public int bigBluePosion;
    public PlayerValue playerValue;

    private void Start()
    {
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");
        PlayerPrefs.SetInt("playerPrefsKey",1);
        PlayerPrefs.SetInt("IsTreePrefabActive",1);
        PlayerPrefs.SetInt("IsTallPrefabActive",1);
        PlayerPrefs.SetInt("IsSnowPrefabActive", 1);
        PlayerPrefs.SetInt("IsBossPrefabActive", 1);
        PlayerPrefs.SetInt("Portal", 0);
        playerValue.InitPlayerVelue();
        playerValue.InitPlayerBagVelue();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private void SavePlayerData()
    {
        hart = playerValue.inithart;
        attack = playerValue.initattack;
        special = playerValue.initspecial;
        coin = playerValue.initcoin;
        smallHealPosion = playerValue.smallHealPosion;
        bigHealPosion = playerValue.bigHealPosion;
        smallBluePosion = playerValue.smallBluePosion;
        bigBluePosion = playerValue.bigBluePosion;
        now = 0;

        PlayerPrefs.SetInt("InitHart", hart);
        PlayerPrefs.SetInt("InitAttack", attack);
        PlayerPrefs.SetInt("InitSpecial", special);
        PlayerPrefs.SetInt("InitCoin", coin);
        PlayerPrefs.SetInt("InitNow", now);
        PlayerPrefs.SetInt("SmallHealPosion", smallHealPosion);
        PlayerPrefs.SetInt("BigHealPosion", bigHealPosion);
        PlayerPrefs.SetInt("SmallBluePosion", smallBluePosion);
        PlayerPrefs.SetInt("BigBluePosion", bigBluePosion);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }
}
