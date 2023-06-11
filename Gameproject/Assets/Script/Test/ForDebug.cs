using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForDebug : MonoBehaviour
{
    private void Update()
    {
        int now = PlayerPrefs.GetInt("InitNow");
        Debug.Log(now);
    }

}
