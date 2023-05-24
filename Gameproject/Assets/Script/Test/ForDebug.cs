using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForDebug : MonoBehaviour
{
    public void Initall()
    {
        PlayerPrefs.DeleteKey("InitHart");
        PlayerPrefs.DeleteKey("InitAttack");
        PlayerPrefs.DeleteKey("InitSpecial");
        PlayerPrefs.DeleteKey("InitCoin");
    }

}
