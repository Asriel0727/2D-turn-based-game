using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb1;

    private Animator animator;

    public Canvas playerUi;

    public Canvas playerBag;

    private Vector2 velocity;

    private float speed = 3;

    public int stop = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(x, y, z);

        }
    }

    void FixedUpdate()
    {
        MovePlayer(player);
    }

    private void Update()
    {
        PlayerUIShow();
    }

    public void MovePlayer(GameObject player)
    {
        rb1 = player.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(speed, 0);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime * stop);
            animator.SetBool("ReadyToRight", true);
            animator.SetBool("ReadyToLeft", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, 0);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime * stop);
            animator.SetBool("ReadyToLeft", true);
            animator.SetBool("ReadyToRight", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            velocity = new Vector2(0, speed);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime * stop);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity = new Vector2(0, -speed);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime * stop);
        }
        else
        {
            animator.SetBool("ReadyToRight", false);
            animator.SetBool("ReadyToLeft", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            PlayerPrefs.SetFloat("PlayerX", this.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", this.transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", this.transform.position.z);
            PlayerPrefs.Save();
        }
    }

    void PlayerUIShow()
    {
        if (Input.GetKey(KeyCode.B) && playerUi.gameObject.activeSelf == false)
        {
            playerBag.gameObject.SetActive(true);
            stop = 0;
        }
        if(Input.GetKey(KeyCode.C) && playerBag.gameObject.activeSelf == false)
        {
            playerUi.gameObject.SetActive(true);
            stop = 0;
        }
    }
}
