using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb1;

    private Vector2 velocity;

    private float speed = 10;

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
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, 0);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity = new Vector2(0, speed);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity = new Vector2(0, -speed);
            rb1.MovePosition(rb1.position + velocity * Time.fixedDeltaTime);
        }
    }
}
