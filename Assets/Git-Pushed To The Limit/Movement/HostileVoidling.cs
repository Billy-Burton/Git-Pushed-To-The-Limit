using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileVoidling : Enemy
{
    private void Update()
    {
        Move(1);
    }

    public override void Jump(Vector2 jumpForce)
    {

    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        //Charge Attack
        //DimensionAttack
        //Cooldown
        //ChangeDimensionBack
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
        //MaybeShootSludge?
    }
}
