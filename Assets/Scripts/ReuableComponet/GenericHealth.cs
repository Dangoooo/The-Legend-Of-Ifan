using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue currentHealth;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  virtual void Heal(float amountToHeal)
    {
        currentHealth.initialValue += amountToHeal;
        if(currentHealth.initialValue > currentHealth.defaultValue)
        {
            currentHealth.initialValue = currentHealth.defaultValue;
        }
    }

    public virtual void FullHeal()
    {
        currentHealth.initialValue = currentHealth.defaultValue;
    }

    public virtual void Damage(float amountToDamage)
    {
        currentHealth.initialValue -= amountToDamage;
        if(currentHealth.initialValue < 0)
        {
            currentHealth.initialValue = 0;
        }
    }

    public virtual void InstantDeath()
    {
        currentHealth.initialValue = 0;
    }
}
