using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class TallMachineReturn : MonoBehaviour
{
    public TallMonster tallMonster1;
    public PlayerValue player;

    public GameObject machine;
    public GameObject main;

    public async void Threenum()
    {
        await Delay(1500);
        End();
        player.heal(50);
        await Delay(1500);
        tallMonster1.BeAttack(100, "ªø¸}©Ç", true);
    }

    public async void Twonum()
    {
        await Delay(1500);
        End();
        tallMonster1.BeAttack(70, "ªø¸}©Ç", true);
        await Delay(1500);
        player.heal(25);
    }

    public async void Onenum()
    {
        await Delay(1500);
        End();
        tallMonster1.BeAttack(50, "ªø¸}©Ç", true);
        await Delay(1500);

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
        End();
    }

    public void Num777()
    {
        player.attack += 10;
        End();
    }
}
