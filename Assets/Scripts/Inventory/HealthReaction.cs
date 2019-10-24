using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public ReSignal healthSignal;
    public FloatValue playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int amountToAdd)
    {
        playerHealth.initialValue += amountToAdd;
        healthSignal.Raise();
    }
}
