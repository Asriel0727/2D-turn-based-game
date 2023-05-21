using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class MachineReturn : MonoBehaviour
{
    public TreeMonster treeMonster1;
    public TreeMonster treeMonster2;
    public TreeMonster treeMonster3;
    public PlayerValue player;

    public GameObject machine;
    public GameObject main;

    public async void Threenum()
    {
        await Delay(1500);
        End();
        await Delay(1500);
        treeMonster1.BeAttack(100, "언㎝1많",true);
        await Delay(1500);
        treeMonster2.BeAttack(100, "언㎝2많", true);
        await Delay(1500);
        treeMonster3.BeAttack(100, "언㎝3많", true);
        player.heal(50);
    }

    public async void Twonum()
    {
        await Delay(1500);
        End();
        await Delay(1500);
        treeMonster1.BeAttack(50, "언㎝1많", true);
        await Delay(1500);
        treeMonster2.BeAttack(50, "언㎝2많", true);
        await Delay(1500);
        treeMonster3.BeAttack(50, "언㎝3많", true);
        player.heal(25);
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
}
