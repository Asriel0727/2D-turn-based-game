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
        smallHeal.text = "³Ñ¾l¶q¡G" + value.smallHealPosion.ToString();
        bigHeal.text = "³Ñ¾l¶q¡G" + value.bigHealPosion.ToString();
        smallBlue.text = "³Ñ¾l¶q¡G" + value.smallBluePosion.ToString();
        bigBlue.text = "³Ñ¾l¶q¡G" + value.bigBluePosion.ToString();
    }
}
