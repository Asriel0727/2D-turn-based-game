using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TallMonsterTag : MonoBehaviour
{
    public GameObject tallEnemy;
    public void Start()
    {
        if (tallEnemy != null && !tallEnemy.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
    private bool inBattle = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !inBattle)
        {
            inBattle = true;
            SceneManager.LoadScene(3);
        }
    }
}
