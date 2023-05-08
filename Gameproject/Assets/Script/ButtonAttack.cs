using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttack : MonoBehaviour
{
    public TreeMonster treeMonster;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    private GameObject selectMonster;
    public GameObject machine;
    public GameObject main;

    public Text debugText;
    public Text turn;

    private int runturn;
    private string monsterName;
    private int monsterNumber;
    // Start is called before the first frame update
    void Start()
    {
        InitVelue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void singleAttack()
    {
        if(selectMonster == null)
        {
            debugText.text = "請選擇攻擊對象";
        }
        else
        {
            debugText.text = "對" + monsterName + "攻擊";
            runturn += 1;
            turn.text = "第" + runturn + "回合";
        }
    }

    public void GroupAttack()
    {

    }

    public void SpecialAttack()
    {
        main.SetActive(false);
        machine.SetActive(true);
    }

    public void SelectMonster(GameObject name)
    {
        if(name.name == "TreeMonster(1)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖1號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
    }

    public void InitVelue()
    {
        runturn = 1;
        debugText.text = " ";
    }
}
