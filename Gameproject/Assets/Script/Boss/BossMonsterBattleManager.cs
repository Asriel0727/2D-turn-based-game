using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossMonsterBattleManager : MonoBehaviour
{
    public BossMonster bossMonster1;
    public PlayerValue playerValue;
    public Canvas winCanvas;
    public Canvas mainCanvas;
    public Text text;
    public Animator boxAnimator;
    public Button button;
    public loading nowNum;

    public int hart;
    public int attack;
    public int special;
    public int coin;
    public int now;
    public void BackLevel()
    {
        PlayerPrefs.SetFloat("LastTriggerPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastTriggerPosY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameObject enemy;

    private void Start()
    {
        boxAnimator.SetBool("isOpen", false);
        text.text = "恭喜你獲得了" + (bossMonster1.dropCoin).ToString() + "枚金幣\n";
        text.text += "請點擊以下寶箱獲得獎勵\n";
    }

    private void Update()
    {
        EndCheck();
    }

    public void EndBattle()
    {
        hart = playerValue.hart;
        attack = playerValue.attack;
        special = playerValue.special;
        coin = playerValue.coin;
        now = nowNum.now;

        PlayerPrefs.SetInt("InitHart", hart);
        PlayerPrefs.SetInt("InitAttack", attack);
        PlayerPrefs.SetInt("InitSpecial", special);
        PlayerPrefs.SetInt("InitCoin", coin);
        PlayerPrefs.SetInt("InitNow", now);
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }

    private void EndCheck()
    {
        if (bossMonster1.isdead == true)
        {
            BattleWinUI();
            PlayerPrefs.SetInt("IsBossPrefabActive", 0);
            PlayerPrefs.SetInt("Portal", 1);
            int num = PlayerPrefs.GetInt("Portal");
            Debug.Log("1：" + num);
            PlayerPrefs.Save();
        }
    }

    private void BattleWinUI()
    {
        winCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void BoxOpen()
    {
        boxAnimator.SetBool("isOpen", true);
        int moreCoin = Random.Range(1, 30);
        text.text += "恭喜你獲得" + moreCoin.ToString() + "枚金幣";
        playerValue.coin += moreCoin;
        button.gameObject.SetActive(true);
    }
}
