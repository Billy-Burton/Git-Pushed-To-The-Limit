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
    protected float attackRange;
    [Tooltip("Enemy Current Dimension: True = Reality, False = Void")]
    public bool dimension;

    public DimensionLeap DimensionLeap;

    [SerializeField]
    private Rigidbody2D rb;

    protected void Death()
    {
        Destroy(gameObject);
    }

    public virtual void Move(float moveAmount)
    {
        rb.velocity = new Vector2(moveAmount * speed, 0.0f);
    }

    void Update()
    {
        if ((dimension == DimensionLeap.dimension) && (Vector2.Distance(transform.position, Player.Instance.transform.position) < attackRange))
        {
            RangedAttack();
        }
    }

    private void OnColliderHit2D(Collision2D target)
    {
        target.gameObject.CompareTag("Player");

        if (dimension == DimensionLeap.dimension)
        {
            Attack(target);
        }

        if (dimension != DimensionLeap.dimension)
        {
            SpecialAttack();
        }
    }

    private void Attack(Collision2D target)
    {
        target.gameObject.SetActive(false);
    }

    public virtual void SpecialAttack()
    {

    }

    public virtual void RangedAttack()
    {

    }

}
