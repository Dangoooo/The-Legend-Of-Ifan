using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Projectile Ability", menuName = "Scritpable Objects/Abilities/Projectile Ability")]

public class ProjectileAbility : GenericAbility
{
    [SerializeField] private GameObject thisProjectile;
    public override void Ability(Vector2 playerPosition, Vector2 playerFacingPosition, Animator ani = null, Rigidbody2D playerRigidbody = null)
    {
        if (magicCost <= playerMagic.initialValue)
        {
            playerMagic.initialValue -= magicCost;
            playerMagicSignal.Raise();
        }
        else
        {
            return;
        }
        if (thisProjectile)
        {
            float temp = Mathf.Atan2(playerFacingPosition.y, playerFacingPosition.x)*Mathf.Rad2Deg;
            GameObject newGameobject = Instantiate(thisProjectile, playerPosition, Quaternion.Euler(0f, 0f, temp));
            GenericProjectile newProjectile = newGameobject.GetComponent<GenericProjectile>();
            if(newProjectile)
            {
                newProjectile.SetUp(playerFacingPosition);
            }
        }
    }
}
