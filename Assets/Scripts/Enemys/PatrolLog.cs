using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentDestination;
    public float homeRadius;

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

     public override void CheckDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) >= attackRadius)
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
        else if (Vector3.Distance(transform.position, target.position) > chaseRadius)
        {
           if(Vector3.Distance(transform.position, currentDestination.position)>homeRadius)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, currentDestination.position, moveSpeed * Time.deltaTime);
                ChangeMoveAnim(position - transform.position);
                myRigidbody.MovePosition(position);
            }
           else
            {
                ChangeDestination();
            }
        }
    }

    private void ChangeDestination()
    {
        if(currentPoint == path.Length-1)
        {
            currentPoint = 0;
            currentDestination = path[0];
        }
        else
        {
            currentPoint++;
            currentDestination = path[currentPoint];
        }
    }
}
