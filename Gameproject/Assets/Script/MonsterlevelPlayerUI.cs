using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonsterlevelPlayerUI : MonoBehaviour
{
    public Canvas playerBagUI;
    public Text warning;

    public PlayerValue playerValue;

    public void PlayerBagUI()
    {
        warning.gameObject.SetActive(false);
        playerBagUI.gameObject.SetActive(false);
    }
    public void SmallHealUse()
    {
        if (playerValue.smallHealPosion >= 1 && playerValue.hart < 100)
        {
            if (playerValue.hart + 20 >= 100)
            {
                int hart = 100;
                playerValue.smallHealPosion -= 1;
                int sp = playerValue.smallHealPosion;
                PlayerPrefs.SetInt("SmallHealPosion", sp);
                PlayerPrefs.SetInt("InitHart", hart);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                playerValue.hart = 100;
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                int hart = playerValue.hart + 20;
                playerValue.smallHealPosion -= 1;
                int sp = playerValue.smallHealPosion;
                PlayerPrefs.SetInt("SmallHealPosion", sp);
                PlayerPrefs.SetInt("InitHart", hart);
                PlayerPrefs.Save();
                warning.gameObject.SetActive(true);
                playerValue.hart += 20;
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if (playerValue.smallHealPosion < 1)
            {
                warning.gameObject.SetActive(true);
                warning.text = "道具數量不足";
                Invoke("SetFalse", 1.5f);
            }
            else if (playerValue.hart >= 100)
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
                int hart = 100;
                playerValue.bigHealPosion -= 1;
                int sp = playerValue.bigHealPosion;
                PlayerPrefs.SetInt("BigHealPosion", sp);
                PlayerPrefs.SetInt("InitHart", hart);
                PlayerPrefs.Save();
                playerValue.hart = 100;
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
            else
            {
                int hart = playerValue.hart + 40;
                playerValue.bigHealPosion -= 1;
                int sp = playerValue.bigHealPosion;
                PlayerPrefs.SetInt("BigHealPosion", sp);
                PlayerPrefs.SetInt("InitHart", hart);
                PlayerPrefs.Save();
                playerValue.hart += 40;
                warning.gameObject.SetActive(true);
                warning.text = "已使用道具，目前血量為" + hart;
                Invoke("SetFalse", 1.5f);
            }
        }
        else
        {
            if (playerValue.bigHealPosion < 1)
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
                int sp = playerValue.smallBluePosion;
                PlayerPrefs.SetInt("SmallHealPosion", sp);
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
                int sp = playerValue.smallBluePosion;
                PlayerPrefs.SetInt("SmallHealPosion", sp);
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
                int sp = playerValue.bigBluePosion;
                PlayerPrefs.SetInt("BigBluePosion", sp);
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
                int sp = playerValue.bigBluePosion;
                PlayerPrefs.SetInt("BigBluePosion", sp);
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
