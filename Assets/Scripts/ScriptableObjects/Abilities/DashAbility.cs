using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[CreateAssetMenu(fileName = "Dash Ability", menuName = "Scritpable Objects/Abilities/Dash Ability")]
public class DashAbility : GenericAbility
{
    public float dashForce;
    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection, Animator ani = null, Rigidbody2D playerRigidbody = null)
    {
        if(magicCost <= playerMagic.initialValue)
        {
            playerMagic.initialValue -= magicCost;
            playerMagicSignal.Raise();
        }
        else
        {
            return;
        }
        if(playerRigidbody)
        {
            Vector2 dashVector = playerPosition + playerFacingDirection.normalized * dashForce;
            playerRigidbody.DOMove(dashVector, duration);
        }

    }
}
    

