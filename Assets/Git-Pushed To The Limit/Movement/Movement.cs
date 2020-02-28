using System.Collections;
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

    private Rigidbody2D rb;

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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Platform"))
        {
            jumped = false;
        }
    }
}
