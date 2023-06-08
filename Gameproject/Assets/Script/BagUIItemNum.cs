using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BagUIItemNum : MonoBehaviour
{
    public Text smallHeal;
    public Text bigHeal;
    public Text smallBlue;
    public Text bigBlue;

    public PlayerValue value;


    private void Update()
    {
        smallHeal.text = "�Ѿl�q�G" + value.smallHealPosion.ToString();
        bigHeal.text = "�Ѿl�q�G" + value.bigHealPosion.ToString();
        smallBlue.text = "�Ѿl�q�G" + value.smallBluePosion.ToString();
        bigBlue.text = "�Ѿl�q�G" + value.bigBluePosion.ToString();
    }
}
