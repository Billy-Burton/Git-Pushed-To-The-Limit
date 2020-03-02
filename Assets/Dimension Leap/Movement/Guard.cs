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

    public override void RangedAttack()
    {
        Debug.Log("Shoot");
        pew.shoot();
    }
}
