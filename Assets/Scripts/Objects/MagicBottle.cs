using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBottle : PowerUp
{
    public ReSignal addMagicSignal;
    public FloatValue playerMagic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMagic.initialValue += 1;
        if(collision.gameObject.tag == "Player")
        {

            addMagicSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
