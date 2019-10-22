using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue maxHealth;
    public float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth.initialValue;
    }
    private void OnEnable()
    {
        currentHealth = maxHealth.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  virtual void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth.initialValue)
        {
            currentHealth = maxHealth.initialValue;
        }
    }

    public virtual void FullHeal()
    {
        currentHealth = maxHealth.initialValue;
    }

    public virtual void Damage(float amountToDamage)
    {
        currentHealth -= amountToDamage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public virtual void InstantDeath()
    {
        currentHealth = 0;
    }
}
