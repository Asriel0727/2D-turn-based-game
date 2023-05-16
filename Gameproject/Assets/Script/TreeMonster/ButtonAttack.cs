using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttack : MonoBehaviour
{
    public TreeMonster treeMonster1;
    public TreeMonster treeMonster2;
    public TreeMonster treeMonster3;
    public PlayerValue player;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    private GameObject selectMonster;
    public GameObject machine;
    public GameObject main;
    public GameObject attackGroup;

    public Text debugText;
    public Text turn;

    private int runturn;
    private string monsterName;
    private int monsterNumber;
    private int playerAttackValue;
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
            attackGroup.SetActive(false);
            debugText.text = "";
            runturn += 1;
            turn.text = "第" + runturn + "回合";
            if(monsterName == "怪物1號")
            {
                playerAttackValue = player.Attack(monsterName);
                treeMonster1.BeAttack(playerAttackValue, monsterName);
            }
            else if (monsterName == "怪物2號")
            {
                playerAttackValue = player.Attack(monsterName);
                treeMonster2.BeAttack(playerAttackValue, monsterName);
            }
            else if (monsterName == "怪物3號")
            {
                playerAttackValue = player.Attack(monsterName);
                treeMonster3.BeAttack(playerAttackValue, monsterName);
            }
            debugText.text = "";
            StartCoroutine(MonsterAttack());
        }
    }

    public void GroupAttack()
    {
        attackGroup.SetActive(false);
        playerAttackValue = player.GroupAttack();
        debugText.text = "發動全體攻擊\n" ;
        runturn += 1;
        turn.text = "第" + runturn + "回合";
        if (treeMonster1 != null)
        {
            monsterName = "怪物1號";
            treeMonster1.BeAttack(playerAttackValue, monsterName);
        }
        if (treeMonster2 != null)
        {
            monsterName = "怪物2號";
            treeMonster2.BeAttack(playerAttackValue, monsterName);
        }
        if (treeMonster3 != null)
        {
            monsterName = "怪物3號";
            treeMonster3.BeAttack(playerAttackValue, monsterName);
        }
        debugText.text = "";
        StartCoroutine(MonsterAttack());
    }

    public void SpecialAttack()
    {
        main.SetActive(false);
        machine.SetActive(true);
    }

    public void SelectMonster(GameObject name)
    {
        if(name.name == "Monster(1)")
        {
            selectMonster = name.gameObject;
            monsterName = "怪物1號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "怪物2號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
        else if (name.name == "Monster(3)")
        {
            selectMonster = name.gameObject;
            monsterName = "怪物3號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        monsterName = "怪物1號";
        treeMonster1.Attack(monsterName);
        yield return new WaitForSeconds(2);
        monsterName = "怪物2號";
        treeMonster2.Attack(monsterName);
        yield return new WaitForSeconds(2);
        monsterName = "怪物3號";
        treeMonster3.Attack(monsterName);
        yield return new WaitForSeconds(2);
        debugText.text = "";
        attackGroup.SetActive(true);
    }

    public void InitVelue()
    {
        runturn = 1;
        debugText.text = " ";
    }
}
