using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject Portal;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Portal") == 1)
        {
            Portal.gameObject.SetActive(true);
        }
        else
        {
            Portal.gameObject.SetActive(false);
        }
    }
}
