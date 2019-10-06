using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot"&&this.gameObject.tag == "Hit")
        {
            collision.GetComponent<Pot>().Destroy();
        }
        if (collision.gameObject.tag == "Enemy"||collision.gameObject.tag == "Player"&&collision.isTrigger)
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                if(collision.gameObject.tag == "Enemy")
                {
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                }
                if(collision.gameObject.tag == "Player")
                {
                    collision.GetComponent<PlayerMove>().Knock(knockTime, damage);
                    hit.GetComponent<PlayerMove>().currentState = PlayerState.stagger;
                }
                Vector2 difference = hit.transform.position - transform.position;
                hit.AddForce(difference.normalized* thrust, ForceMode2D.Impulse);
              
            }
        }
    }

}
