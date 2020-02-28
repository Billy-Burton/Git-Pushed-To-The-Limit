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

    public override void Attack(Enemy target)
    {
        RaycastHit2D attack = Physics2D.Raycast(transform.position, transform.forward);

    }
}
