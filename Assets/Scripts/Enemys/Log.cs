using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    protected Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    protected Animator anim;
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if(Vector3.Distance(transform.position, target.position)<=chaseRadius && Vector3.Distance(transform.position,target.position)>=attackRadius)
        {
            if(currentState == EnemyState.walk||currentState == EnemyState.idle&&currentState != EnemyState.stagger)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeMoveAnim(position-transform.position);
                myRigidbody.MovePosition(position);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            } 
        }
        else if(Vector3.Distance(transform.position, target.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    public void ChangeMoveAnim(Vector2 direction)
    {
        direction.Normalize();
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }
}
