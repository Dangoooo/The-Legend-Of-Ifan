using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : PowerUp
{
    public ReSignal healthSignal;
    public FloatValue playerHealth;
    public float healthIncrease;
    public FloatValue heartContainers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            playerHealth.initialValue += healthIncrease;
            if (playerHealth.initialValue > heartContainers.initialValue*2)
            {
                playerHealth.initialValue = heartContainers.initialValue*2;
            }
            healthSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
