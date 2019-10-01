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
    public bool isOpen;
    public SpriteRenderer doorSprite;
    public Sprite doorOpenSprite;
    public BoxCollider2D physicisCollider;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(!isOpen)
            {
                if(playerInventory.numberOfKeys>0&&currentDoorType == DoorType.key)
                {
                    OpenDoor();
                }
            }
            else
            {

            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        playerInventory.numberOfKeys--;
        doorSprite.sprite = doorOpenSprite;
        physicisCollider.enabled = false;
        contextClueSignal.Raise();
    }

    private void CloseDoor()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger && !isOpen)
        {
            contextClueSignal.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger && !isOpen)
        {
            contextClueSignal.Raise();
            playerInRange = false;
        }
    }
}
