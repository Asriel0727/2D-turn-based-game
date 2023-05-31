using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIValue : MonoBehaviour
{
    public Text hart;
    public Text attack;
    public Text smallHeal;
    public Text bigHeal;
    public Text smallBlue;
    public Text bigBlue;
    public Text coin;
    public PlayerValue value;

    private void Update()
    {
        hart.text = "血量：" + value.hart.ToString();
        attack.text = "基礎攻擊力：" + value.attack.ToString();
        smallHeal.text = "補血藥劑(小)：" + value.smallHealPosion.ToString();
        bigHeal.text = "補血藥劑(大)：" + value.bigHealPosion.ToString();
        smallBlue.text = "氣勢藥劑(小)：" + value.smallBluePosion.ToString();
        bigBlue.text = "氣勢藥劑(大)：" + value.bigBluePosion.ToString();
        coin.text = "擁有金幣：" + value.coin.ToString();
    }
}
