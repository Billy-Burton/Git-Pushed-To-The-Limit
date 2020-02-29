using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackRange;
    [SerializeField]
    private bool stun = false;
    [Tooltip("Enemy Current Dimension: True = Reality, False = Void")]
    public bool dimension;

    public DimensionLeap DimensionLeap;

    [SerializeField]
    private Rigidbody2D rb;

    public LayerMask enemyMask;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    public bool isGrounded;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    protected void Death()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        if(!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        if (!stun)
        {
            Vector2 myVel = myBody.velocity;
            myVel.x = -myTrans.right.x * speed;
            myBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + myVel * Time.deltaTime);
        }

        else if(stun)
        {
            StartCoroutine(StunTimer());
        }

        if ((dimension == DimensionLeap.dimension) && (Vector3.Distance(transform.position, Player.Instance.transform.position) < attackRange))
        {
            Debug.Log("In Range");
            RangedAttack();
        }
    }

    private void OnColliderHit2D(Collision2D target)
    {
        if(target.gameObject.CompareTag("Player"))
        {
            if (dimension == DimensionLeap.dimension)
            {
                Attack(target);
            }

            if (dimension != DimensionLeap.dimension)
            {
                SpecialAttack();
            }
        }
    }

    public void Stunned()
    {
        Debug.Log("Stun");
        stun = true;
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

    IEnumerator StunTimer()
    {
        yield return new WaitForSecondsRealtime(5);
        stun = false;
    }

}
