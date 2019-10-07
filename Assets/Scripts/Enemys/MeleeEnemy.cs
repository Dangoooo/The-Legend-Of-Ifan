using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Log
{
    public override void CheckDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) > attackRadius)
        {
            if (currentState == EnemyState.walk || currentState == EnemyState.idle && currentState != EnemyState.stagger)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeMoveAnim(position - transform.position);
                myRigidbody.MovePosition(position);
                ChangeState(EnemyState.walk);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) <= attackRadius)
        {
            if (currentState == EnemyState.walk || currentState == EnemyState.idle && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

    private IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("attacking", false);
        currentState = EnemyState.walk;
    }
}
