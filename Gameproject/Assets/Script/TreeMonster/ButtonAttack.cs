using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

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
    private bool canskip = false;
    // Start is called before the first frame update
    void Start()
    {
        InitVelue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void singleAttack()
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
            if(monsterName == "��1��")
            {
                playerAttackValue = player.Attack(monsterName);
                await Delay(1000);
                treeMonster1.BeAttack(playerAttackValue, monsterName,canskip);
            }
            else if (monsterName == "��2��")
            {
                playerAttackValue = player.Attack(monsterName);
                await Delay(1000);
                treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            }
            else if (monsterName == "��3��")
            {
                playerAttackValue = player.Attack(monsterName);
                await Delay(1000);
                treeMonster3.BeAttack(playerAttackValue, monsterName, canskip);
            }
            debugText.text = "";
            StartCoroutine(MonsterAttack());
        }
    }

    public async void GroupAttack()
    {
        attackGroup.SetActive(false);
        playerAttackValue = player.GroupAttack();
        debugText.text = "�o�ʥ������\n" ;
        await Delay(1000);
        runturn += 1;
        turn.text = "��" + runturn + "�^�X";
        if (treeMonster1 != null)
        {
            monsterName = "��1��";
            treeMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1000);
        }
        if (treeMonster2 != null)
        {
            monsterName = "��2��";
            treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1000);
        }
        if (treeMonster3 != null)
        {
            monsterName = "��3��";
            treeMonster3.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1000);
        }
        if(treeMonster1 != null || treeMonster2 != null || treeMonster3 != null)
        {
            debugText.text = "";
            StartCoroutine(MonsterAttack());
        }
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
            monsterName = "��1��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "��2��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
        else if (name.name == "Monster(3)")
        {
            selectMonster = name.gameObject;
            monsterName = "��3��";
            monsterNumber = 1;
            debugText.text = "�w���" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        monsterName = "��1��";
        treeMonster1.Attack(monsterName);
        yield return new WaitForSeconds(1);
        monsterName = "��2��";
        treeMonster2.Attack(monsterName);
        yield return new WaitForSeconds(1);
        monsterName = "��3��";
        treeMonster3.Attack(monsterName);
        yield return new WaitForSeconds(1);
        debugText.text = "";
        attackGroup.SetActive(true);
    }

    public void InitVelue()
    {
        runturn = 1;
        debugText.text = " ";
    }

    private async Task Delay(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }
}
