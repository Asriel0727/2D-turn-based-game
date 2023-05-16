using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeMonster : MonoBehaviour
{
    private int hart;
    private int attack;
    private int special;
    public bool isdead;

    private int randomBreak;
    private bool isBreak;

    private int randomSkip;
    private bool isSkip;

    public PlayerValue playerValue;
    public Text hartText;
    public Text debugText;
    public loading loading;
    void Start()
    {
        InitMonsterVelue();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterHartCheck();
    }

    private bool MonsterHartCheck()
    {
        if(hart <= 0)
        {
            Destroy(this.gameObject);
            isdead = true;
            return isdead;
        }
        else
        {
            isdead = false;
            return isdead;
        }
    }

    private void InitMonsterVelue()
    {
        hart = 100;
        attack = 5;
        special = 10;
    }

    public void BeAttack(int value, string name)
    {
        if(SkipCheck())
        {
            debugText.text += name +　"閃避了攻擊" + "\n";
        }
        else
        {
            debugText.text += "對" + name + "造成" + value + "傷害" + "\n";
            hart = hart - value;
            loading.now += 10;
            hartText.text = hart.ToString();
        }
    }

    private bool SkipCheck()
    {
        randomSkip = Random.Range(0, 10);
        if(randomSkip > 7)
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

    public void Attack(string name)
    {
        randomBreak = Random.Range(0, 10);
        
        if(randomBreak > 8)
        {
            isBreak = true;
            attack = 15;
        }
        else
        {
            isBreak = false;
        }

        playerValue.BeAttack(name, attack);
    }
}
