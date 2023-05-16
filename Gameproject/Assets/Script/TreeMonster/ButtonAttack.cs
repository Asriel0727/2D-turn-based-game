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
            debugText.text = "�п�ܧ�����H";
        }
        else
        {
            attackGroup.SetActive(false);
            debugText.text = "";
            runturn += 1;
            turn.text = "��" + runturn + "�^�X";
            if(monsterName == "�Ǫ�1��")
            {
                playerAttackValue = player.Attack(monsterName);
                treeMonster1.BeAttack(playerAttackValue, monsterName);
            }
            else if (monsterName == "�Ǫ�2��")
            {
                playerAttackValue = player.Attack(monsterName);
                treeMonster2.BeAttack(playerAttackValue, monsterName);
            }
            else if (monsterName == "�Ǫ�3��")
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
        debugText.text = "�o�ʥ������\n" ;
        runturn += 1;
        turn.text = "��" + runturn + "�^�X";
        if (treeMonster1 != null)
        {
            monsterName = "�Ǫ�1��";
            treeMonster1.BeAttack(playerAttackValue, monsterName);
        }
        if (treeMonster2 != null)
        {
            monsterName = "�Ǫ�2��";
            treeMonster2.BeAttack(playerAttackValue, monsterName);
        }
        if (treeMonster3 != null)
        {
            monsterName = "�Ǫ�3��";
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
            monsterName = "�Ǫ�1��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "�Ǫ�2��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
        else if (name.name == "Monster(3)")
        {
            selectMonster = name.gameObject;
            monsterName = "�Ǫ�3��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        monsterName = "�Ǫ�1��";
        treeMonster1.Attack(monsterName);
        yield return new WaitForSeconds(2);
        monsterName = "�Ǫ�2��";
        treeMonster2.Attack(monsterName);
        yield return new WaitForSeconds(2);
        monsterName = "�Ǫ�3��";
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
