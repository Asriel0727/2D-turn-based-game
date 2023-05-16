using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour
{
    private int hart;
    private int attack;
    private int special;

    private int randomBreak;
    private bool isBreak;

    private int randomSkip;
    private bool isSkip;

    public Text hartText;
    public Text debugText;
    public GameObject attackGroup;
    void Start()
    {
        InitPlayerVelue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitPlayerVelue()
    {
        hart = 100;
        attack = 20;
        special = 50;
    }

    public void BeAttack(string name, int value)
    {
        if (SkipCheck())
        {
            debugText.text += "您閃避了攻擊" + "\n";
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
            return attack;
        }
        else
        {
            attack = 20;
            return attack;
        }

    }

    public int GroupAttack()
    {
        attack = 10;
        return attack;
    }
}
