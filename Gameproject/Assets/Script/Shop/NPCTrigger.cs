using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public Canvas uIShop;

    public GameObject shopIcon;

    public SoundController soundController;

    public void OnTriggerStay2D(Collider2D collision)
    {
        shopIcon.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.W))
        {
            uIShop.gameObject.SetActive(true);
            soundController.PlaySound2();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        uIShop.gameObject.SetActive(false);
        shopIcon.gameObject.SetActive(false);
    }
}
