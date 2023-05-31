using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Canvas shopUI;
    public Canvas playerUI;
    public PlayerValue player;
    public VillagePlayerController playerController;
    public TextLoader text;

    public Image buttonImage1;
    public Text buttonTextError1;

    public Image buttonImage2;
    public Text buttonTextError2;

    public Image buttonImage3;
    public Text buttonTextError3;

    public Image buttonImage4;
    public Text buttonTextError4;

    private void Start()
    {
        text.LoadTextFile();
        StartCoroutine(text.TypeText());
    }
    public void CloseShop()
    {
        shopUI.gameObject.SetActive(false);
    }

    public void ClosePlayerUI()
    {
        playerUI.gameObject.SetActive(false);
        playerController.stop = 1;
    }

    public void Item1Select()
    {
        if (player.coin > 10)
        {
            player.coin -= 10;
            player.smallHealPosion += 1;
        }
        else
        {
            buttonImage1.enabled = false;
            buttonTextError1.gameObject.SetActive(true);
            Invoke("OpenImage", 2.5f);
        }
    }

    public void Item2Select()
    {
        if(player.coin > 20)
        {
            player.coin -= 20;
            player.bigHealPosion += 1;
        }
        else
        {
            buttonImage2.enabled = false;
            buttonTextError2.gameObject.SetActive(true);
            Invoke("OpenImage", 2.5f);
        }
    }

    public void Item3Select()
    {
        if(player.coin > 40)
        {
            player.coin -= 40;
            player.smallBluePosion += 1;
        }
        else
        {
            buttonImage3.enabled = false;
            buttonTextError3.gameObject.SetActive(true);
            Invoke("OpenImage", 2.5f);
        }
    }


    public void Item4Select()
    {
        if(player.coin >¡@80)
        {
            player.coin -= 80;
            player.bigBluePosion += 1;
        }
        else
        {
            buttonImage4.enabled = false;
            buttonTextError4.gameObject.SetActive(true);
            Invoke("OpenImage", 2.5f);
        }

    }

    private void OpenImage()
    {
        buttonImage1.enabled = true;
        buttonTextError1.gameObject.SetActive(false);
        buttonImage2.enabled = true;
        buttonTextError2.gameObject.SetActive(false);
        buttonImage3.enabled = true;
        buttonTextError3.gameObject.SetActive(false);
        buttonImage4.enabled = true;
        buttonTextError4.gameObject.SetActive(false);
    }
}
