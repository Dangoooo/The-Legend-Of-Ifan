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
    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        if(currentState != EnemyState.stagger)
        {
            TakeDamage(damage);
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
}
