using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{
    public Signal enemyOpenDoorSignal;
    public LootTable lootTable;
    public GameObject deathEffect;
    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        if (currentHealth <= 0)
        {
            if (enemyOpenDoorSignal != null)
            {
                enemyOpenDoorSignal.Raise();
            }
            CreateLoot();
            this.gameObject.SetActive(false);
            DeathEffect();
        }
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject gb = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gb, 1f);
        }
    }

    private void CreateLoot()
    {
        if (lootTable != null)
        {
            PowerUp power = lootTable.CreateLoot();
            if (power != null)
            {
                Instantiate(power.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
