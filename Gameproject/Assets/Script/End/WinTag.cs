using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinTag : MonoBehaviour
{
    public Canvas winCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("playerPrefsKey", 2);
            winCanvas.gameObject.SetActive(true);
        }
    }
}
