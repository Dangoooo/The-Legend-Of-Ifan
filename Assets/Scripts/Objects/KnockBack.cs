using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
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
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy" ) && collision.isTrigger)
        {
            Rigidbody2D hit = collision.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = (hit.transform.position - transform.position).normalized*thrust;
                hit.DOMove(difference + hit.position, knockTime);
                if (collision.gameObject.tag == "Enemy")
                {
                    collision.GetComponent<Enemy>().Knock(hit, knockTime);
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                }
                if (collision.gameObject.tag == "Player")
                {
                    collision.GetComponentInParent<PlayerMove>().Knock(knockTime);
                    hit.GetComponentInParent<PlayerMove>().currentState = PlayerState.stagger;
                }
            }

        }
    }

}
