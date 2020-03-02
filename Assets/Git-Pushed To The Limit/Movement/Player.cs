using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Collider2D footCollider;
    public static Player Instance { get; private set; }

    [Header("Movement")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool jumped = false;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float bounceForce;
    public bool Immune = false;
    public bool jumping = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footCollider.isTrigger = true;
    }

    void Update()
    {
        CheckForJump();
        RaycastHit2D fallOn = Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f);

        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if ((jumping) && (!jumped)) 
        {
            jumped = true;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumping = false;
        }
    }

    public void CheckForJump()
    {
        if(Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space))))
        {
            jumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(Immune)
            {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumped = false;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            this.rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            other.gameObject.GetComponent<Enemy>().Stunned();
        }
    }
}
