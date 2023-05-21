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
        attackGroup.SetActive(false);
        debugText.text = "";
        runturn += 1;
        turn.text = "第" + runturn + "回合";
        monsterName = "長腳怪";
        playerAttackValue = player.Attack(monsterName);
        await Delay(1500);
        tallMonster1.BeAttack(playerAttackValue, monsterName, canskip);
        debugText.text = "";
        StartCoroutine(MonsterAttack());
    }

    public async void GroupAttack()
    {
        attackGroup.SetActive(false);
        playerAttackValue = player.GroupAttack();
        debugText.text = "發動全體攻擊\n";
        await Delay(1500);
        runturn += 1;
        turn.text = "第" + runturn + "回合";
        if (tallMonster1 != null)
        {
            monsterName = "長腳怪";
            tallMonster1.BeAttack(playerAttackValue, monsterName, canskip);
            await Delay(1500);
        }
        debugText.text = "";
        StartCoroutine(MonsterAttack());
    }

    public void SpecialAttack()
    {
        main.SetActive(false);
        machine.SetActive(true);
    }
    IEnumerator MonsterAttack()
    {
        monsterName = "長腳怪";
        tallMonster1.Attack(monsterName);
        yield return new WaitForSeconds(2);
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
