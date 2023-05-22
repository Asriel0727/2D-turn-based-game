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

    public GameObject monster1;
    public GameObject monster2;
    //public GameObject monster1;
    //public GameObject monster1;

    public PlayerValue playerValue;
    private void Start()
    {
        playerValue.InitPlayerVelue();
        // ���s���a��m
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");

        //���s�Ǫ�
        monster1.gameObject.SetActive(true);
        monster2.gameObject.SetActive(true);

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

        PlayerPrefs.SetInt("InitHart", hart);
        PlayerPrefs.SetInt("InitAttack", attack);
        PlayerPrefs.SetInt("InitSpecial", special);
        PlayerPrefs.SetInt("InitCoin", coin);
        PlayerPrefs.Save();

        Debug.Log(hart);
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }
}
