using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class Door : Interactable
{
    public DoorType currentDoorType;
    public Inventory playerInventory;
    public BoolValue isOpen;
    public SpriteRenderer doorSprite;
    public Sprite doorOpenSprite;
    public Sprite doorCloseSprite;
    public BoxCollider2D physicisCollider;
    void Start()
    {
        if(isOpen.initialValue)
        {
            doorSprite.sprite = doorOpenSprite;
            physicisCollider.enabled = false;
        }
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Attack") && playerInRange)
        {
            if(!isOpen.initialValue)
            {
                if(playerInventory.numberOfKeys>0&&currentDoorType == DoorType.key)
                {
                    OpenDoor();
                    contextClueSignal.Raise();
                }
            }
            else
            {

            }
        }
    }

    public void OpenDoor()
    {
        isOpen.initialValue = true;
        if(currentDoorType == DoorType.key)
        {
            playerInventory.numberOfKeys--;
        }
        doorSprite.sprite = doorOpenSprite;
        physicisCollider.enabled = false;
    }

    public void CloseDoor()
    {
        isOpen.initialValue = false;
        doorSprite.sprite = doorCloseSprite;
        physicisCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger && !isOpen.initialValue)
        {
            contextClueSignal.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger && !isOpen.initialValue)
        {
            contextClueSignal.Raise();
            playerInRange = false;
        }
    }
}
