using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLog : Log
{
    public Collider2D boundry;

    private void Update()
    {
        CheckDistance();
    }
    public override void CheckDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) >= attackRadius && boundry.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.walk || currentState == EnemyState.idle && currentState != EnemyState.stagger)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeMoveAnim(position - transform.position);
                myRigidbody.MovePosition(position);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > chaseRadius || !boundry.bounds.Contains(target.transform.position))
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }
}
