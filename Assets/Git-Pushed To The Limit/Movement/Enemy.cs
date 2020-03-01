using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite sameDimension;
    public Sprite otherDimension;

    [Header("Enemy Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackRange;
    [SerializeField]
    private bool stun = false;
    public bool canMove = true;
    public bool realityDimension;

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
        CheckDimension();
        CheckForGround();
        TurnEnemy();
        Movement();
    }

    //UpdateMethods
    public void CheckDimension()
    {
        if (realityDimension == DimensionLeap.dimension)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sameDimension;
        }

        else if (realityDimension != DimensionLeap.dimension)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = otherDimension;
        }
    }

    public void CheckForGround()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
    }

    public void TurnEnemy()
    {
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
    }

    public void Movement()
    {
        if ((!stun) && (canMove))
        {
            Vector2 myVel = myBody.velocity;
            myVel.x = -myTrans.right.x * speed;
            myBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + myVel * Time.deltaTime);
        }

        else if (stun)
        {
            StartCoroutine(StunTimer());
        }
    }

    //Player Interaction
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched");
            Attack(other);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("VoidTouched");
            SpecialAttack();
        }
    }

    //Stunned Enemy
    public void Stunned()
    {
        Debug.Log("Stun");
        stun = true;
    }

    IEnumerator StunTimer()
    {
        yield return new WaitForSecondsRealtime(5);
        stun = false;
    }

    //Attacks
    private void Attack(Collision2D other)
    {
        other.gameObject.SetActive(false);
    }

    public virtual void SpecialAttack()
    {

    }

    public virtual void RangedAttack()
    {

    }

}
