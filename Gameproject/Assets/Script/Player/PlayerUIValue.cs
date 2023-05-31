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
        hart.text = "��q�G" + value.hart.ToString();
        attack.text = "��¦�����O�G" + value.attack.ToString();
        smallHeal.text = "�ɦ��ľ�(�p)�G" + value.smallHealPosion.ToString();
        bigHeal.text = "�ɦ��ľ�(�j)�G" + value.bigHealPosion.ToString();
        smallBlue.text = "����ľ�(�p)�G" + value.smallBluePosion.ToString();
        bigBlue.text = "����ľ�(�j)�G" + value.bigBluePosion.ToString();
        coin.text = "�֦������G" + value.coin.ToString();
    }
}
