using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagePlayerController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb1;

    private Animator animator;

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
        else
        {
            animator.SetBool("ReadyToRight", false);
            animator.SetBool("ReadyToLeft", false);
        }
    }
}
