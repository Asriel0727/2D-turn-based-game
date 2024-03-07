using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{
    public PlayerValue value;

    public GameObject tips;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tips.gameObject.SetActive(true);

        if(Input.GetKey(KeyCode.W))
        {
            PlayerPrefs.SetInt("InitHart", value.hart);
            PlayerPrefs.SetInt("InitAttack", value.attack);
            PlayerPrefs.SetInt("InitSpecial", value.special);
            PlayerPrefs.SetInt("InitCoin", value.coin);
            PlayerPrefs.SetInt("SmallHealPosion", value.smallHealPosion);
            PlayerPrefs.SetInt("BigHealPosion", value.bigHealPosion);
            PlayerPrefs.SetInt("SmallBluePosion", value.smallBluePosion);
            PlayerPrefs.SetInt("BigBluePosion", value.bigBluePosion);
            PlayerPrefs.Save();

            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tips.gameObject.SetActive(false);
    }
}