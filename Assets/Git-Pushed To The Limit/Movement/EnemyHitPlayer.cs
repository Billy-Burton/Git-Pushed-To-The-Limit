using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    private void OnCollisionHit2D(Collider2D hit)
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
