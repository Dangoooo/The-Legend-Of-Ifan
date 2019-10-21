using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    public Signal healthSignal;
    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        healthSignal.Raise();
        if(currentHealth.initialValue == 0)
        {
           
        }
    }
}
