﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool jumped = false;
    [SerializeField]
    private Vector2 jumpForce;
    [SerializeField]
    private Vector2 bounceForce;

    private Rigidbody2D rb;

    RaycastHit2D fallOn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * speed * Time.deltaTime, 0.0f);

        if ((Input.GetKeyDown(KeyCode.W)) && (!jumped))
        {
            jumped = true;
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        checkBelow();
    }

    private void checkBelow()
    {
        fallOn = Physics2D.Raycast(transform.position, -transform.up, 2.0f);

        if(fallOn.collider.gameObject.CompareTag("Enemy"))
        {
            enemyBelow();
        }
    }

    private void enemyBelow()
    {
        fallOn.collider.GetComponent<GameObject>().SetActive(false);
        rb.AddForce(bounceForce, ForceMode2D.Impulse);
    }
}