using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    public Signal healthSignal;
    public GameObject player;
    public FloatValue playerHealth;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }
    public override void Damage(float amountToDamage)
    {
        playerHealth.initialValue -= amountToDamage;
        healthSignal.Raise();
        if(playerHealth.initialValue <= 0)
        {
            playerHealth.initialValue = 0;
            player.SetActive(false);
        }
    }

    public override void Heal(float amountToHeal)
    {
        playerHealth.initialValue += amountToHeal;
    }

    public override void FullHeal()
    {
        playerHealth.initialValue = maxHealth.initialValue;
    }

    public override void InstantDeath()
    {
        playerHealth.initialValue = 0;
    }
}
