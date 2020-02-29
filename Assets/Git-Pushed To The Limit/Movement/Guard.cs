using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject Bullet;

    private void OnDrawGizmos()
    {

    }

    private void Update()
    {
        Move(1);
    }

    public override void RangedAttack()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(1);
    }
}
