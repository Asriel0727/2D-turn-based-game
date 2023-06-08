using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public int smallHealPosion;
    public int bigHealPosion;
    public int smallBluePosion;
    public int bigBluePosion;

    private int randomBreak;
    private bool isBreak;

    private int randomSkip;
    private bool isSkip;

    public Text hartText;
    public Text debugText;
    public GameObject attackGroup;
    public Animator animator;
    public loading loading;

    void Start()
    {
        if (PlayerPrefs.HasKey("InitHart") && PlayerPrefs.HasKey("InitAttack") && PlayerPrefs.HasKey("InitSpecial") && PlayerPrefs.HasKey("InitCoin"))
        {
            hart = PlayerPrefs.GetInt("InitHart");
            attack = PlayerPrefs.GetInt("InitAttack");
            special = PlayerPrefs.GetInt("InitSpecial");
            coin = PlayerPrefs.GetInt("InitCoin");
            hartText.text = hart.ToString();
        }
        else
        {
            InitPlayerVelue();
            hartText.text = inithart.ToString();
        }

        if(PlayerPrefs.HasKey("SmallHealPosion") && PlayerPrefs.HasKey("BigHealPosion") && PlayerPrefs.HasKey("SmallBluePosion") && PlayerPrefs.HasKey("BigBluePosion"))
        {
            smallHealPosion = PlayerPrefs.GetInt("SmallHealPosion");
            bigHealPosion = PlayerPrefs.GetInt("BigHealPosion");
            smallBluePosion = PlayerPrefs.GetInt("SmallBluePosion");
            bigBluePosion = PlayerPrefs.GetInt("BigBluePosion");
        }
        else
        {
            InitPlayerBagVelue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeadChack();
    }

    public void PlayerDeadChack()
    {
        if(hart <= 0)
        {
            SceneManager.LoadScene(8);
        }
    }

    public void InitPlayerBagVelue()
    {
        smallHealPosion = 3;
        bigHealPosion = 1;
        smallBluePosion = 0;
        bigBluePosion = 0;
    }

    public void InitPlayerVelue()
    {
        inithart = 100;
        initattack = 20;
        initspecial = 50;
        initcoin = 40;
    }

    public void BeAttack(string name, int value)
    {
        if (SkipCheck())
        {
            debugText.text += "您閃避了"+ name +"的攻擊" + "\n";
        }
        else
        {
            AnimationHart(true);
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
            loading.now += 5;
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
        int buttonattack = 0;
        if (BreakChack())
        {
            PlayerAttackAnimation(isBreak);
            buttonattack = attack * 2;
            loading.now += 10;
            return buttonattack;
        }
        else
        {
            PlayerAttackAnimation(isBreak);
            buttonattack = attack;
            return buttonattack;
        }
    }

    public int GroupAttack()
    {
        int buttonattack = 0;
        if(BreakChack())
        {
            buttonattack = attack;
            PlayerAttackAnimation(isBreak);
            return buttonattack;
        }
        else
        {
            buttonattack = attack / 2;
            PlayerAttackAnimation(isBreak);
            return buttonattack;
        }
    }

    public void heal(int value)
    {
        hart += value;
    }

    public void PlayerAttackAnimation(bool isBreak)
    {
        if(isBreak)
        {
        }
        else
        {
        }
    }

    public bool BreakChack()
    {
        randomBreak = Random.Range(0, 10);

        if (randomBreak > 8)
        {
            isBreak = true;
            return isBreak;
        }
        else
        {
            isBreak = false;
            return isBreak;
        }
    }

    public void AnimationAttack()
    {
        int num = Random.Range(1, 4);
        animator.SetInteger("AttackNumber", num);
        animator.SetBool("Wait", false);
    }

    public void AnimationWait()
    {
        animator.SetInteger("AttackNumber", 0);
        animator.SetBool("Wait", true);
    }

    public void AnimationHart(bool isBeAttack)
    {
        animator.SetBool("Hart", isBeAttack);
    }
}
