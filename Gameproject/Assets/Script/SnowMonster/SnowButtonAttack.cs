using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SnowButtonAttack : MonoBehaviour
{
    public SnowMonster snowMonster1;
    public SnowMonster snowMonster2;
    public PlayerValue player;

    public GameObject monster1;
    public GameObject monster2;
    private GameObject selectMonster;

    public GameObject machine;
    public GameObject main;
    public GameObject attackGroup;

    public Text debugText;
    public Text turn;
    public Button spinButton;
    public Canvas bagcanvas;

    private int runturn;
    private string monsterName;
    private int playerAttackValue;
    private bool canskip = false;

    void Start()
    {
        InitVelue();
    }

    public void Bag()
    {
        bagcanvas.gameObject.SetActive(true);
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
            if(monsterName == "雪怪1號")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                snowMonster1.BeAttack(playerAttackValue, monsterName,canskip);
                await Delay(1500);
            }
            else if (monsterName == "雪怪2號")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                snowMonster2.BeAttack(playerAttackValue, monsterName, canskip);
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
        if (snowMonster1 != null)
        {
            monsterName = "雪怪1號";
            snowMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (snowMonster2 != null)
        {
            monsterName = "雪怪2號";
            snowMonster2.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if(snowMonster1 != null || snowMonster2 != null)
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
            monsterName = "雪怪1號";
            debugText.text = "已選擇" + monsterName;
        }
        else if(name.name == "Monster(2)")
        {
            selectMonster = name.gameObject;
            monsterName = "雪怪2號";
            debugText.text = "已選擇" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        if(snowMonster1 != null)
        {
            monsterName = "雪怪1號";
            snowMonster1.Attack(monsterName);
            yield return new WaitForSeconds(1);
        }
        if(snowMonster2 != null)
        {
            monsterName = "雪怪2號";
            snowMonster2.Attack(monsterName);
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
    }
}
