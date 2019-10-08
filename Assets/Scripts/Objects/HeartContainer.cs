using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public FloatValue heartContainers;
    public FloatValue playerHealth;
    public Signal healthSignal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            heartContainers.initialValue++;
            playerHealth.initialValue = heartContainers.initialValue * 2;
            healthSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
