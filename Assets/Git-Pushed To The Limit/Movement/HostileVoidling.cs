using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileVoidling : Enemy
{
    private void Update()
    {
        Move(1);
    }

    public override void SpecialAttack()
    {
        //Play Charging Animation
        StartCoroutine(Charge());
        //Stop Animation
        //Show Reality Sprite
        dimension = true;
        //Play Stunned Animation
        StartCoroutine(Stunned());
        //Show Void Sprite
        dimension = false;
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
        //MaybeShootSludge?
    }

    IEnumerator Charge()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSecondsRealtime(2);
    }
}
