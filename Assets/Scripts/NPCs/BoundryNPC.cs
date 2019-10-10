using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryNPC : Interactable
{
    private Rigidbody2D myRigidbody;
    private Animator anim;
    private Vector2 moveDirection;
    public Collider2D boundry;
    public float speed;
    public GameObject target;
    private bool isInteractable;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeDirection();
    }

  
    void Update()
    {
        Interact();
        Move();
    }

    private void Move()
    {
        if(!isInteractable)
        {
            anim.SetBool("walking", true);
            anim.SetFloat("moveX", moveDirection.x);
            anim.SetFloat("moveY", moveDirection.y);
            Vector2 temp = myRigidbody.position + moveDirection * speed * Time.deltaTime;
            if (boundry.bounds.Contains(temp))
            {
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            anim.SetBool("walking", false);
            Vector2 temp = target.GetComponent<Rigidbody2D>().position - myRigidbody.position;
            temp = temp.normalized;
            anim.SetFloat("moveX", temp.x);
            anim.SetFloat("moveY", temp.y);
        }
      
       
    }

    private void ChangeDirection()
    {
        int changeDirection = Random.Range(0, 4);
        switch (changeDirection)
        {
            case 0 :
                moveDirection = Vector2.up;
                break;
            case 1:
                moveDirection = Vector2.right;
                break;
            case 2:
                moveDirection = Vector2.down;
                break;
            case 3:
                moveDirection = Vector2.left;
                break;
            default:
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection();
    }

    private void Interact()
    {
        if(Input.GetButtonDown("Attack") && playerInRange)
        {
            isInteractable = true;
        }
    }
}
