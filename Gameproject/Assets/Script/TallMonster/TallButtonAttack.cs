using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class TallButtonAttack : MonoBehaviour
{
    public TallMonster tallMonster1;
    public PlayerValue player;

    public GameObject monster1;
    public GameObject machine;
    public GameObject main;
    public GameObject attackGroup;
    private GameObject selectMonster;

    public Text debugText;
    public Text turn;
    public Button spinButton;

    private int runturn;
    private string monsterName;
    private int playerAttackValue;
    private bool canskip = false;
    // Start is called before the first frame update
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
            debugText.text = "�п�ܧ�����H";
        }
        else
        {
            MonsterCheckFalse();
            attackGroup.SetActive(false);
            debugText.text = "";
            if (monsterName == "���}��")
            {
                player.AnimationAttack();
                playerAttackValue = player.Attack(monsterName);
                tallMonster1.BeAttack(playerAttackValue, monsterName, canskip);
                await Delay(1500);
            }
            if (debugText != null && turn != null)
            {
                debugText.text = "";
                StartCoroutine(MonsterAttack());
                runturn += 1;
                turn.text = "��" + runturn + "�^�X";
                player.AnimationWait();
            }
        }
    }

    public async void GroupAttack()
    {
        attackGroup.SetActive(false);
        MonsterCheckFalse();
        playerAttackValue = player.GroupAttack();
        debugText.text = "�o�ʥ������\n";
        player.AnimationAttack();
        await Delay(1500);
        if (tallMonster1 != null)
        {
            monsterName = "���}��";
            tallMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (tallMonster1 != null)
        {
            player.AnimationWait();
            debugText.text = "";
            StartCoroutine(MonsterAttack());
            runturn += 1;
            turn.text = "��" + runturn + "�^�X";
        }
    }

    public void SpecialAttack()
    {
        runturn += 1;
        turn.text = "��" + runturn + "�^�X";
        main.SetActive(false);
        machine.SetActive(true);
        spinButton.gameObject.SetActive(true);
    }

    public void SelectMonster(GameObject name)
    {
        if (name.name == "Monster(1)")
        {
            selectMonster = name.gameObject;
            monsterName = "���}��";
            debugText.text = "�w���" + monsterName;
        }
    }

    IEnumerator MonsterAttack()
    {
        if (tallMonster1 != null)
        {
            monsterName = "���}��";
            tallMonster1.Attack(monsterName);
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
        if (monster1.gameObject != null)
        {
            monster1.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    private void MonsterCheckTrue()
    {
        if (monster1.gameObject != null)
        {
            monster1.gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
