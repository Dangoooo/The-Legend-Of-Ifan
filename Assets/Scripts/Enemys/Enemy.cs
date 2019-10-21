using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public float moveSpeed;
    public int baseAttack;
    public string enemyName;
    public GameObject deathEffect;
    public Vector2 homePosition;
    public Signal enemyOpenDoorSignal;
    public LootTable lootTable;
    private void Awake()
    {
        health = maxHealth.initialValue;
        transform.position = homePosition;
        
    }

    private void OnEnable()
    {
        health = maxHealth.initialValue;
        transform.position = homePosition;
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        if(currentState != EnemyState.stagger)
        {
            if (health > 0)
            {
                StartCoroutine(KnockCo(myRigidbody, knockTime));
            }
        }
    }
    IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle; 

        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            if(enemyOpenDoorSignal != null)
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
        if(deathEffect != null)
        {
            GameObject gb = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gb, 1f);
        }
    }

    private void CreateLoot()
    {
        if(lootTable != null)
        {
            PowerUp power = lootTable.CreateLoot();
            if(power != null)
            {
                Instantiate(power.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
