using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;
    public float initialLifeTime;
    private float lifeTime;
    void Start()
    {
        lifeTime = initialLifeTime;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime<0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Launch(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
