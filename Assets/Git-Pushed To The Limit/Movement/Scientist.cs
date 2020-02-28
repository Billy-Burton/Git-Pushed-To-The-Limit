using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : Enemy
{   
    private void Update()
    {
        Move(1);
    }

    public override void Jump(Vector2 jumpForce)
    {

    }

    public override void Attack(Enemy target)
    {
        base.Attack(target);
    }

}
