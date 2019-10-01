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
        if (collision.gameObject.tag == "Enemy"||collision.gameObject.tag == "Player")
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                if(collision.gameObject.tag == "Enemy")
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(collision.gameObject.tag == "Player")
                {
                    hit.GetComponent<PlayerMove>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMove>().Knock(knockTime, damage);
                }
                Vector2 difference = hit.transform.position - transform.position;
                hit.AddForce(difference.normalized* thrust, ForceMode2D.Impulse);
              
            }
        }
    }

}
