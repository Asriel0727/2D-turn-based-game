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
    public loading loading;

    public async void Threenum()
    {
        await Delay(1500);
        End();
        tallMonster1.BeAttack(100, "ªø¸}©Ç", true);
        player.heal(50);
    }

    public async void Twonum()
    {
        await Delay(1500);
        End();
        tallMonster1.BeAttack(50, "ªø¸}©Ç", true);
        player.heal(25);
    }

    public void End()
    {
        loading.now = 0;
        main.SetActive(true);
        machine.SetActive(false);
    }

    private async Task Delay(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }
}
