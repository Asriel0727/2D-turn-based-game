using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class BossButtonAttack : MonoBehaviour
{
    public BossMonster bossMonster1;
    public PlayerValue player;

    public GameObject monster1;
    public GameObject machine;
    public GameObject main;
    public GameObject attackGroup;
    private GameObject selectMonster;

    public Text debugText;
    public Text turn;
    public Button spinButton;
    public Canvas bagcanvas;

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

    public void Bag()
    {
        bagcanvas.gameObject.SetActive(true);
    }

    public async void singleAttack()
    {
         monsterName = "BOSS";
         MonsterCheckFalse();
         attackGroup.SetActive(false);
         debugText.text = "";
        if (monsterName == "BOSS")
        {
            player.AnimationAttack();
            playerAttackValue = player.Attack(monsterName);
            bossMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (debugText != null && turn != null)
        {
            debugText.text = "";
            StartCoroutine(MonsterAttack());
            runturn += 1;
            turn.text = "第" + runturn + "回合";
            player.AnimationWait();
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
        if (bossMonster1 != null)
        {
            monsterName = "BOSS";
            bossMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        if (bossMonster1 != null)
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

    IEnumerator MonsterAttack()
    {
        if (bossMonster1 != null)
        {
            monsterName = "BOSS";
            bossMonster1.Attack(monsterName);
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
