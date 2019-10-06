using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLog : Log
{
    public GameObject rockProjectile;
    public float initialProjectileDelay;
    private float projectileDelay;
    private bool isProjectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        projectileDelay -= Time.deltaTime;
        if(projectileDelay <= 0f)
        {
            isProjectile = false;
            projectileDelay = initialProjectileDelay;
        }
        CheckDistance();
    }

    public override void CheckDistance()
    {
        if (Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) >= attackRadius && !isProjectile)
        {
            if (currentState == EnemyState.walk || currentState == EnemyState.idle && currentState != EnemyState.stagger)
            { 
                Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeMoveAnim(position - transform.position);
                Vector3 tempDirection = target.position - transform.position;
                GameObject tempObject = Instantiate(rockProjectile, transform.position, Quaternion.identity);
                tempObject.GetComponent<RockProjectile>().Launch(tempDirection);
                isProjectile = true;
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > chaseRadius)
        {
           
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }
}
