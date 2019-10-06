using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialLifeTime;
    private float lifeTime;
    public float speed;
    public Rigidbody2D myRigidbody;

    void Start()
    {
        lifeTime = initialLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 direction)
    {
        myRigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject); 
    }
}
