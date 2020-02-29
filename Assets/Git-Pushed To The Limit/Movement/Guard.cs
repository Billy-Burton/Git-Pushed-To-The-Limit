using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    private void Update()
    {
        Move(1);
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
        //shoot player
    }
}
