using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    public GuardGun pew;

    public bool inRange = false;
    private void OnDrawGizmos()
    {

    }

    private void Update()
    {
        Move(1);
    }

    public override void RangedAttack()
    {
        StartCoroutine(Reload());
        pew.shoot();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(1);
    }
}
