using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMamager : MonoBehaviour
{
    public void BackToVillage()
    {
        Debug.Log("1");
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        Debug.Log("2");
        SceneManager.LoadScene(0);
    }

}
