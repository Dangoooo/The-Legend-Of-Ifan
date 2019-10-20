using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public Signal receiveCoinSignal;
    public PlayerInventory playerInventory;
    void Start()
    {
        receiveCoinSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            playerInventory.numberOfCoins++;
            receiveCoinSignal.Raise();
            Destroy(this.gameObject);
        }  
    }
}
