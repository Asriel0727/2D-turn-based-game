using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTag : MonoBehaviour
{
   public GameObject bossEnemy;
    private void Start()
    {
        if (PlayerPrefs.GetInt("IsBossPrefabActive") == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private bool inBattle = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !inBattle)
        {
            inBattle = true;
            SceneManager.LoadScene(7);
        }
    }
}
