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
    public Button spinButton;

    private int runturn;
    private string monsterName;
    private int playerAttackValue;
    private bool canskip = false;

    void Start()
    {
        InitVelue();
    }

    void Update()
    {
        
    }

    public async void singleAttack()
    {
        if (selectMonster == null)
        {
            debugText.text = "請選擇攻擊對象";
        }
        else
        {
            MonsterCheckFalse();
            attackGroup.SetActive(false);
            debugText.text = "";
            if(monsterName == "樹妖1號")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                treeMonster1.BeAttack(playerAttackValue, monsterName,canskip);
                await Delay(1500);
            }
            else if (monsterName == "樹妖2號")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
                await Delay(1500);
            }
            else if (monsterName == "樹妖3號")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                treeMonster3.BeAttack(playerAttackValue, monsterName, canskip);
                await Delay(1500);
            }
            if(debugText != null && turn != null)
            {
                debugText.text = "";
                StartCoroutine(MonsterAttack());
                runturn += 1;
                turn.text = "第" + runturn + "回合";
                player.AnimationWait();
            }
        }
    }

    public async void GroupAttack()
    {
        attackGroup.SetActive(false);
        MonsterCheckFalse();
        playerAttackValue = player.GroupAttack();
        debugText.text = "發動全體攻擊\n";
        player.AnimationAttack();
        await Delay(1500);
        if (treeMonster1 != null)
        {
            monsterName = "樹妖1號";
            treeMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (treeMonster2 != null)
        {
            monsterName = "樹妖2號";
            treeMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (treeMonster3 != null)
        {
            monsterName = "樹妖3號";
            treeMonster3.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if(treeMonster1 != null || treeMonster2 != null || treeMonster3 != null)
        {
            player.AnimationWait();
            debugText.text = "";
            StartCoroutine(MonsterAttack());
            runturn += 1;
            turn.text = "第" + runturn + "回合";
        }
    }

    public void SpecialAttack()
    {
        runturn += 1;
        turn.text = "第" + runturn + "回合";
        main.SetActive(false);
        machine.SetActive(true);
        spinButton.gameObject.SetActive(true);
    }

    public void SelectMonster(GameObject name)
    {
        if(name.name == "Monster(1)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖1號";
            debugText.text = "已選擇" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖2號";
            debugText.text = "已選擇" + monsterName;
        }
        else if (name.name == "Monster(3)")
        {
            selectMonster = name.gameObject;
            monsterName = "樹妖3號";
            debugText.text = "已選擇" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        if(treeMonster1 != null)
        {
            monsterName = "樹妖1號";
            treeMonster1.Attack(monsterName);
            yield return new WaitForSeconds(1);
        }
        if(treeMonster2 != null)
        {
            monsterName = "樹妖2號";
            treeMonster2.Attack(monsterName);
            yield return new WaitForSeconds(1);
        }
        if(treeMonster3 != null)
        {
            monsterName = "樹妖3號";
            treeMonster3.Attack(monsterName);
            yield return new WaitForSeconds(1);
        }
        debugText.text = "";
        attackGroup.SetActive(true);
        MonsterCheckTrue();
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

    private void MonsterCheckFalse()
    {
        if(monster1.gameObject != null)
        {
            monster1.gameObject.GetComponent<Button>().enabled = false;
        }
        if (monster2.gameObject != null)
        {
            monster2.gameObject.GetComponent<Button>().enabled = false;
        }
        if (monster3.gameObject != null)
        {
            monster3.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    private void MonsterCheckTrue()
    {
        if (monster1.gameObject != null)
        {
            monster1.gameObject.GetComponent<Button>().enabled = true;
        }
        if (monster2.gameObject != null)
        {
            monster2.gameObject.GetComponent<Button>().enabled = true;
        }
        if (monster3.gameObject != null)
        {
            monster3.gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
