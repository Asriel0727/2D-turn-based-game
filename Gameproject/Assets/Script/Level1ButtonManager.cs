using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1ButtonManager : MonoBehaviour
{
    public Canvas playerUI;
    public Canvas playerBagUI;
    public PlayerValue playerValue;
    public PlayerController playerController;

    public Text playerBagCoin;
    public Text warning;

    private void Update()
    {
        playerBagCoin.text = playerValue.coin.ToString();
    }
    public void PlayerUIClose()
    {
        playerController.stop = 1;
        playerUI.gameObject.SetActive(false);
        
    }

    public void PlayerBagUI()
    {
        playerController.stop = 1;
        warning.gameObject.SetActive(false);
        playerBagUI.gameObject.SetActive(false);
    }

    public void BackToVillage() 
    {
        playerController.stop = 0;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        playerController.stop = 0;
        SceneManager.LoadScene(0);
    }

    public void SmallHealUse()
    {
        if (playerValue.smallHealPosion >= 1 && playerValue.hart < 100)
        {
            if(playerValue.hart + 20 >= 100)
            {
                playerValue.hart = 100;
                int hart = 100;
                playerValue.smallHealPosion -= 1;
                PlayerPrefs.SetInt("InitHart", hart);
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                playerValue.hart += 20;
                int hart = playerValue.hart + 20;
                playerValue.smallHealPosion -= 1;
                PlayerPrefs.SetInt("InitHart", hart);
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if(playerValue.smallHealPosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "道具數量不足";
                Invoke("SetFalse", 1.5f);
            }
            else if(playerValue.hart >= 100)
            {
                warning.gameObject.SetActive(true);
                warning.text = "您的血量已滿";
                Invoke("SetFalse", 1.5f);
            }
        }
    }

    public void BigHealUse()
    {
        if (playerValue.bigHealPosion >= 1 && playerValue.hart < 100)
        {
            if (playerValue.hart + 40 >= 100)
            {
                playerValue.hart = 100;
                int hart = 100;
                playerValue.bigHealPosion -= 1;
                PlayerPrefs.SetInt("InitHart", hart);
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                playerValue.hart += 40;
                int hart = playerValue.hart + 40;
                playerValue.bigHealPosion -= 1;
                PlayerPrefs.SetInt("InitHart", hart);
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if(playerValue.bigHealPosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "道具數量不足";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "您的血量已滿";
                Invoke("SetFalse", 1.5f);
            }
        }
    }

    public void SmallBlueUse()
    {
        int now = PlayerPrefs.GetInt("InitNow");
        if (playerValue.smallBluePosion >= 1 && now < 100)
        {
            if (now + 35 >= 100)
            {
                now = 100;
                playerValue.smallBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前氣勢值為" + now;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                now += 35;
                playerValue.smallBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前氣勢值為" + now;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if (playerValue.smallBluePosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "道具數量不足";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "您的氣勢值已滿";
                Invoke("SetFalse", 1.5f);
            }    
        }
    }

    public void BigBlueUse()
    {
        int now = PlayerPrefs.GetInt("InitNow");
        if (playerValue.bigBluePosion >= 1 && now < 100)
        {
            if (now + 35 >= 100)
            {
                now = 100;
                playerValue.bigBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前氣勢值為" + now;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                now += 35;
                playerValue.bigBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前氣勢值為" + now;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if (playerValue.bigBluePosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "道具數量不足";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "您的氣勢值已滿";
                Invoke("SetFalse", 1.5f);
            }
        }
    }

    public void SetFalse()
    {
        warning.gameObject.SetActive(false);
    }
}
