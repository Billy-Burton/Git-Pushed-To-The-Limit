using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileVoidling : Enemy
{
    public Enemy move;
    [SerializeField]
    private GameObject voidling;

    public override void SpecialAttack()
    {
        move.canMove = false;
        Debug.Log("VoidTouched 2");
        StartCoroutine(Charge());
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
    }

    IEnumerator Charge()
    {
        yield return new WaitForSecondsRealtime(2);
        voidling.gameObject.layer = 9;
        Debug.Log("Reality");
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(2);
        voidling.gameObject.layer = 10;
        move.canMove = true;
        Debug.Log("Void");
    }
}
