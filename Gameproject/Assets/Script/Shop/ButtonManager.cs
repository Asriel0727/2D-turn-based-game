using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Canvas shopUI;
    public PlayerValue player;
    public TextLoader text;

    private void Start()
    {
        text.LoadTextFile();
        StartCoroutine(text.TypeText());
    }
    public void Close()
    {
        shopUI.gameObject.SetActive(false);
    }

    public void Item1Select()
    {
        player.coin -= 10;
        player.smallHealPosion += 1;
    }

    public void Item2Select()
    {
        player.coin -= 20;
        player.bigHealPosion += 1;
    }

    public void Item3Select()
    {
        player.coin -= 40;
        player.smallBluePosion += 1;
    }


    public void Item4Select()
    {
        player.coin -= 80;
        player.bigBluePosion += 1;
    }
}
