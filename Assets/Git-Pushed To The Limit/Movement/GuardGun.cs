using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGun : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform Gun;
    [SerializeField]
    private GameObject Bullet;

    private Vector2 shootingDirection;
    private float lookAngle;

    [SerializeField]
    public void Update()
    {
        shootingDirection = target.transform.position - transform.position;
        lookAngle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
    }

    public void shoot()
    {
        GameObject firedBullet = Instantiate(Bullet, Gun.position, Gun.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Gun.up * 10f;
    }

}
