using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : GenericDamage
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
        {
            PlayerHealth temp = collision.gameObject.GetComponent<PlayerHealth>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }
}
