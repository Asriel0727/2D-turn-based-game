using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnowBattleManager : MonoBehaviour
{
    public SnowMonster snowMonster1;
    public SnowMonster snowMonster2;
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
        // 保存觸發器的位置到PlayerPrefs
        PlayerPrefs.SetFloat("LastTriggerPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastTriggerPosY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameObject enemy;

    private void Start()
    {
        boxAnimator.SetBool("isOpen", false);
        text.text = "恭喜你獲得了" + (snowMonster1.dropCoin + snowMonster2.dropCoin).ToString() + "枚金幣\n";
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
        if(snowMonster1.isdead == true && snowMonster2.isdead == true)
        {
            BattleWinUI();
            PlayerPrefs.SetInt("IsSnowPrefabActive", 0);
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
