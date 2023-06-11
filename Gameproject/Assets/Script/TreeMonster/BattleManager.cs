using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    public TreeMonster treeMonster1;
    public TreeMonster treeMonster2;
    public TreeMonster treeMonster3;
    public PlayerValue playerValue;
    public Canvas winCanvas;
    public Canvas mainCanvas;
    public Text text;
    public Animator boxAnimator;
    public Button box;
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
        text.text = "恭喜你獲得了" + (treeMonster1.dropCoin + treeMonster2.dropCoin + treeMonster2.dropCoin).ToString() + "枚金幣\n";
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
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }

    private void EndCheck()
    {
        if(treeMonster1.isdead == true && treeMonster2.isdead == true && treeMonster3.isdead == true)
        {
            BattleWinUI();
            PlayerPrefs.SetInt("IsTreePrefabActive", 0);
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
        box.interactable = false;
        int moreCoin = Random.Range(1, 30);
        text.text += "恭喜你獲得" + moreCoin.ToString() + "枚金幣";
        playerValue.coin += moreCoin;
        button.gameObject.SetActive(true);
    }
}
