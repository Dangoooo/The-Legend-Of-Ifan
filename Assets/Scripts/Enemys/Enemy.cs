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
    public float moveSpeed;
    public int baseAttack;
    public string enemyName;
    public Vector2 homePosition;
    private void Awake()
    {
        transform.position = homePosition;
        
    }

    private void OnEnable()
    {
        transform.position = homePosition;
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        if(currentState != EnemyState.stagger)
        {
             StartCoroutine(KnockCo(myRigidbody, knockTime));
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
}
