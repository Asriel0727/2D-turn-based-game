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
            debugText.text = "請選擇攻擊對象";
        }
        else
        {
            attackGroup.SetActive(false);
            debugText.text = "";
            runturn += 1;
            turn.text = "第" + runturn + "回合";
            if(monsterName == "樹妖1號")
            {
                playerAttackValue = player.Attack(monsterName);
                await Delay(1000);
                treeMonster1.BeAttack(playerAttackValue, monsterName,canskip);
            }
            else if (monsterName == "樹妖2號")
            {
                playerAttackValue = player.Attack(monsterName);
                await Delay(1000);
                treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            }
            else if (monsterName == "樹妖3號")
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
        debugText.text = "發動全體攻擊\n" ;
        await Delay(1000);
        runturn += 1;
        turn.text = "第" + runturn + "回合";
        if (treeMonster1 != null)
        {
            monsterName = "樹妖1號";
            treeMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1000);
        }
        if (treeMonster2 != null)
        {
            monsterName = "樹妖2號";
            treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1000);
        }
        if (treeMonster3 != null)
        {
            monsterName = "樹妖3號";
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
            monsterName = "樹妖1號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖2號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
        else if (name.name == "Monster(3)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖3號";
            monsterNumber = 1;
            debugText.text = "已選擇" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        monsterName = "樹妖1號";
        treeMonster1.Attack(monsterName);
        yield return new WaitForSeconds(1);
        monsterName = "樹妖2號";
        treeMonster2.Attack(monsterName);
        yield return new WaitForSeconds(1);
        monsterName = "樹妖3號";
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
