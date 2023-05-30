using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public Canvas uIShop;

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.W))
        {
            uIShop.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        uIShop.gameObject.SetActive(false);
    }
}
