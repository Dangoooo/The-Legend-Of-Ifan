using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Generic Ability", menuName = "Scritpable Objects/Abilities/Generic Ability")]
public class GenericAbility : ScriptableObject
{
    public float magicCost;
    public float duration;
    public FloatValue playerMagic;
    public ReSignal playerMagicSignal;

    public virtual void Ability(Vector2 playerPosition, Vector2 playerFacingPosition, Animator ani = null, Rigidbody2D playerRigidbody = null)
    {
        
    }
}
