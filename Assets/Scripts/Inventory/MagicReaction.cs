using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReaction : MonoBehaviour
{
    public FloatValue playerMagic;
    public ReSignal magicSignal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int amountToAdd)
    {
        playerMagic.initialValue += amountToAdd;
        magicSignal.Raise();
    }
}
