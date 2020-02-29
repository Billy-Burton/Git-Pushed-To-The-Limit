using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void OntriggerEnter2D (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this);
            other.gameObject.SetActive(false);
        }

        else
        {
            Destroy(this);
        }
    }
}
