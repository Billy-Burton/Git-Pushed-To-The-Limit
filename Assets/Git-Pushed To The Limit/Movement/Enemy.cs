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

    public Transform groundDetection;

    [SerializeField]
    private bool movingLeft = true;

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
        if ((dimension == DimensionLeap.dimension) && (Vector3.Distance(transform.position, Player.Instance.transform.position) < attackRange))
        {
            Debug.Log("In Range");
            RangedAttack();
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2.0f);
        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
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
