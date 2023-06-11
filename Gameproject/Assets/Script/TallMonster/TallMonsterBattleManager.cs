using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TallMonsterBattleManager : MonoBehaviour
{
    public TallMonster tallMonster1;
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
        PlayerPrefs.SetFloat("LastTriggerPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastTriggerPosY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameObject enemy;

    private void Start()
    {
        boxAnimator.SetBool("isOpen", false);
        text.text = "���ߧA��o�F" + (tallMonster1.dropCoin).ToString() + "�T����\n";
        text.text += "���I���H�U�_�c��o���y\n";
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
        if (tallMonster1.isdead == true)
        {
            BattleWinUI();
            PlayerPrefs.SetInt("IsTallPrefabActive", 0);
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
        text.text += "���ߧA��o" + moreCoin.ToString() + "�T����";
        playerValue.coin += moreCoin;
        button.gameObject.SetActive(true);
    }
}
