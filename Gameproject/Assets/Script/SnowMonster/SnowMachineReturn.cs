using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SnowMachineReturn : MonoBehaviour
{
    public SnowMonster snowMonster1;
    public SnowMonster snowMonster2;
    public PlayerValue player;

    public GameObject machine;
    public GameObject main;

    private int startRange = 1;
    private int endRange = 3;

    private int num1, num2;

    public async void Threenum()
    {
        await Delay(1500);
        End();
        player.heal(50);
        await Delay(1500);
        snowMonster1.BeAttack(100, "雪怪1號",true);
        await Delay(1500);
        snowMonster2.BeAttack(100, "雪怪2號", true);

    }

    public async void Twonum()
    {
        RandomNum();
        if(num1 == 1)
        {
            await Delay(1500);
            End();
            snowMonster1.BeAttack(70, "雪怪1號", true);
            await Delay(1500);
        }
        if (num1 == 2)
        {
            await Delay(1500);
            End();
            snowMonster2.BeAttack(70, "雪怪2號", true);
            await Delay(1500);
        }

        if (num2 == 1)
        {
            await Delay(1500);
            End();
            snowMonster1.BeAttack(70, "雪怪1號", true);
            await Delay(1500);
        }
        if (num2 == 2)
        {
            await Delay(1500);
            End();
            snowMonster2.BeAttack(70, "雪怪2號", true);
            await Delay(1500);
        }

        player.heal(25);
    }

    public async void Onenum()
    {
        RandomNum();
        if (num1 == 1)
        {
            await Delay(1500);
            End();
            snowMonster1.BeAttack(50, "雪怪1號", true);
            await Delay(1500);
        }
        if (num2 == 2)
        {
            await Delay(1500);
            End();
            snowMonster2.BeAttack(50, "雪怪2號", true);
            await Delay(1500);
        }
    }

    public void End()
    {
        main.SetActive(true);
        machine.SetActive(false);
    }

    private async Task Delay(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }

    public void Num666()
    {
        player.coin += 15;
    }

    public void Num777()
    {
        player.attack += 10;
    }

    public void RandomNum()
    {
        do
        {
            num1 = Random.Range(startRange, endRange + 1);
            num2 = Random.Range(startRange, endRange + 1);
        } while (num1 == num2);
    }
}
