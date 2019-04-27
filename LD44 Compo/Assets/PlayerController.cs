using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;

    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = moveDirection * speed;
    }
}
