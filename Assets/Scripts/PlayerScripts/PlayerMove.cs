using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class PlayerMove : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    Rigidbody2D myRigidbody;
    Animator animator;
    Vector2 change;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue playerPosition;
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;
    public GameObject receiveItem;
    public GameObject projectile;
    public Signal decreaseMagicSignal;
    public FloatValue playerMagic;
    public Color flareColor;
    public Color regularColor;
    public float flareDuration;
    private SpriteRenderer mySpriteRenderer;
    public Collider2D triggerCollider;
    public int numberOfFlare;
    void Start()
    {
        transform.position = playerPosition.initialValue;
        currentState = PlayerState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack&&currentState != PlayerState.stagger)
        {
                StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("SecondWeapen") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (playerMagic.initialValue > 0)
            {
                StartCoroutine(SecondAttackCo());
            }
              
        }
        else if (currentState == PlayerState.walk||currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        currentState = PlayerState.attack;
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        //yield return new WaitForSeconds(0.3f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.idle;
        }
    }

    private IEnumerator SecondAttackCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        CreateArrow();
        yield return new WaitForSeconds(0.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.idle;
        }
    }

    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receiveItem", true);
                currentState = PlayerState.interact;
                receiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
                receiveItem.SetActive(true);
            }
            else
            {
                animator.SetBool("receiveItem", false);
                currentState = PlayerState.idle;
                receiveItemSprite.sprite = null;
                receiveItem.SetActive(false);
            }
        }

    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector2.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            currentState = PlayerState.walk;
            MoveCharacter();
        }
        else
        {
            animator.SetBool("moving", false);
            currentState = PlayerState.idle;
        }
    }
    private void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(myRigidbody.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        if(currentState != PlayerState.stagger)
        {
            currentHealth.initialValue -= damage;
            playerHealthSignal.Raise();
            if (currentHealth.initialValue > 0)
            {
                StartCoroutine(KnockCo(knockTime));
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            StartCoroutine(FlareCo());
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    IEnumerator FlareCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while(temp<numberOfFlare)
        {
            mySpriteRenderer.color = flareColor;
            yield return new WaitForSeconds(flareDuration);
            mySpriteRenderer.color = regularColor;
            yield return new WaitForSeconds(flareDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }

    private void CreateArrow()
    {
        Arrow arrow = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Arrow>();
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        Vector3 direction = new Vector3(0, 0, temp);
        arrow.Launch(new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY")), direction);
        decreaseMagicSignal.Raise();
    }
}
