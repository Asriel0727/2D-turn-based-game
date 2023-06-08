using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagePlayerController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb1;

    private Animator animator;

    public Canvas playerUi;

    private Vector2 velocity;

    private float speed = 3;

    public int stop = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

    void PlayerUIShow()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            bool isActive = playerUi.gameObject.activeSelf;
            playerUi.gameObject.SetActive(!isActive);
            if(isActive)
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
