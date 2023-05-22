using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour
{
    public int inithart;
    public int initattack;
    public int initspecial;
    public int initcoin;

    public int hart;
    public int attack;
    public int special;
    public int coin;

    private int randomBreak;
    private bool isBreak;

    private int randomSkip;
    private bool isSkip;

    public Text hartText;
    public Text debugText;
    public GameObject attackGroup;
    void Start()
    {
        if (PlayerPrefs.HasKey("InitHart") && PlayerPrefs.HasKey("InitAttack") && PlayerPrefs.HasKey("InitSpecial") && PlayerPrefs.HasKey("InitCoin"))
        {
            hart = PlayerPrefs.GetInt("InitHart");
            attack = PlayerPrefs.GetInt("InitAttack");
            special = PlayerPrefs.GetInt("InitSpecial");
            coin = PlayerPrefs.GetInt("InitCoin");
        }
        else
        {
            InitPlayerVelue();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitPlayerVelue()
    {
        inithart = 100;
        initattack = 20;
        initspecial = 50;
        initcoin = 0;
    }

    public void BeAttack(string name, int value)
    {
        if (SkipCheck())
        {
            debugText.text += "您閃避了"+ name +"的攻擊" + "\n";
        }
        else
        {
            debugText.text += name + "對您造成" + value + "傷害" + "\n";
            hart = hart - value;
            hartText.text = hart.ToString();
        }
    }

    private bool SkipCheck()
    {
        randomSkip = Random.Range(0, 10);
        if (randomSkip > 7)
        {
            isSkip = true;
            return isSkip;
        }
        else
        {
            isSkip = false;
            return isSkip;
        }
    }

    public int Attack(string name)
    {
        randomBreak = Random.Range(0, 10);

        if (randomBreak > 8)
        {
            isBreak = true;
        }
        else
        {
            isBreak = false;
        }
        
        if(isBreak)
        {
            attack = 40;
            debugText.text += "對" + name + "造成了" + attack + "傷害";
            return attack;
        }
        else
        {
            attack = 20;
            debugText.text += "對" + name + "造成了" + attack + "傷害";
            return attack;
        }
    }

    public int GroupAttack()
    {
        attack = 10;
        return attack;
    }

    public void heal(int value)
    {
        hart += value;
    }
}
