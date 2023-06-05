using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(2);
        }
    }
}
