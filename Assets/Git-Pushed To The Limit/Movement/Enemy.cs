using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Vector2 jumpForce;

    [SerializeField]
    private Rigidbody2D rb;

    protected void Death()
    {
        Destroy(gameObject);
    }

    public virtual void Move(float moveAmount)
    {
        rb.velocity = new Vector2(moveAmount * speed, rb.velocity.y);
    }

    public virtual void Jump()
    {
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    public virtual void Attack(Enemy target)
    {

    }
}
