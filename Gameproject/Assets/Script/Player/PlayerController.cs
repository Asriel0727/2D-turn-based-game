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
        velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(speed, 0);
            animator.SetBool("ReadyToRight", true);
            animator.SetBool("ReadyToLeft", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, 0);
            animator.SetBool("ReadyToLeft", true);
            animator.SetBool("ReadyToRight", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity = new Vector2(0, -speed);
        }

        rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime * stop);

        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetBool("ReadyToRight", false);
        }
        if (!Input.GetKey(KeyCode.A))
        {
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
        if (Input.GetKeyDown(KeyCode.B) && playerUi.gameObject.activeSelf == false)
        {
            bool isActive = playerBag.gameObject.activeSelf;
            playerBag.gameObject.SetActive(!isActive);
            if (isActive)
            {
                stop = 1;
            }
            else
            {
                stop = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.C) && playerBag.gameObject.activeSelf == false)
        {
            bool isActive = playerUi.gameObject.activeSelf;
            playerUi.gameObject.SetActive(!isActive);
            if (isActive)
            {
                stop = 1;
            }
            else
            {
                stop = 0;
            }
        }
    }
}
