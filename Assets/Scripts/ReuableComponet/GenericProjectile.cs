using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericProjectile : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField] private float speed;
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetUp(Vector2 moveDirection)
    {
        myRigidbody.velocity = moveDirection.normalized * speed;
    }
}
