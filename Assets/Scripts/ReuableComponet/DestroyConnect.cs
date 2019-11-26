using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyConnect : MonoBehaviour
{
    public GameObject thisGameobject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            Destroy(thisGameobject);
        }
    }
}
