using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle,
    dead,
    ability
}
public class PlayerMove : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    public float attackDuration;
    Rigidbody2D myRigidbody;
    Animator animator;
    Vector2 change;
    Vector2 facingDirection;


    public VectorValue playerPosition;
    public PlayerInventory playerInventory;
    public InventoryItem sword;
    public InventoryItem bow;
    public SpriteRenderer receiveItemSprite;
    public GameObject receiveItem;
    public GameObject projectile;
    public ReSignal decreaseMagicSignal;
    public FloatValue playerMagic;
    public Color flareColor;
    public Color regularColor;
    public float flareDuration;
    private SpriteRenderer mySpriteRenderer;
    private Collider2D triggerCollider;
    public GameObject playerHealth;
    public int numberOfFlare;

    public GenericAbility currentAbility;
    void Start()
    {
        facingDirection = Vector2.down;
        triggerCollider = playerHealth.GetComponent<Collider2D>();
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
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack&&currentState != PlayerState.stagger && currentState != PlayerState.ability && playerInventory.myInventory.Contains(sword))
        {
                StartCoroutine(AttackCo(attackDuration));
        }
        else if (Input.GetButtonDown("Ability") && currentState != PlayerState.attack && currentState != PlayerState.stagger && currentState != PlayerState.ability)
        {
             if(currentAbility)
            {
                StartCoroutine(AbilityCo(currentAbility.duration));
            }
        }
        else if (currentState == PlayerState.walk||currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo(float attackDuration)
    {
        currentState = PlayerState.attack;
        animator.SetBool("attacking", true);
        yield return new WaitForSeconds(attackDuration);
        animator.SetBool("attacking", false);
        currentState = PlayerState.idle;
      
    }

    public IEnumerator AbilityCo(float abilityDuration)
    {
        currentState = PlayerState.ability;
        currentAbility.Ability(myRigidbody.position, facingDirection, animator, myRigidbody);
        yield return new WaitForSeconds(abilityDuration);
        currentState = PlayerState.idle;
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
            facingDirection = change.normalized;
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

    public void Knock(float knockTime)
    {
        if(currentState != PlayerState.stagger)
        {
            StartCoroutine(KnockCo(knockTime));
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
        playerMagic.initialValue -= 1;
        decreaseMagicSignal.Raise();
    }
}
