using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        playerBagUI.gameObject.SetActive(false);
    }
    
    public void SmallHealUse()
    {
        if (playerValue.smallHealPosion >= 1 && playerValue.hart < 100)
        {
            if(playerValue.hart + 20 >= 100)
            {
                playerValue.hart = 100;
                playerValue.smallHealPosion -= 1;
            }
            else
            {
                playerValue.hart += 20;
                playerValue.smallHealPosion -= 1;
            }
        }
        else
        {
            if(playerValue.smallHealPosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "�D��ƶq����";
                Invoke("SetFalse", 1.5f);
            }
            else if(playerValue.hart >= 100)
            {
                warning.gameObject.SetActive(true);
                warning.text = "�z����q�w��";
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
                playerValue.bigHealPosion -= 1;
            }
            else
            {
                playerValue.hart += 40;
                playerValue.bigHealPosion -= 1;
            }
        }
        else
        {
            if(playerValue.bigHealPosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "�D��ƶq����";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "�z����q�w��";
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
            }
            else
            {
                now += 35;
                playerValue.smallBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (playerValue.smallBluePosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "�D��ƶq����";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "�z����խȤw��";
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
            }
            else
            {
                now += 35;
                playerValue.bigBluePosion -= 1;
                PlayerPrefs.SetInt("InitNow", now);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (playerValue.bigBluePosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "�D��ƶq����";
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                warning.gameObject.SetActive(true);
                warning.text = "�z����խȤw��";
                Invoke("SetFalse", 1.5f);
            }
        }
    }

    public void SetFalse()
    {
        warning.gameObject.SetActive(false);
    }
}