using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public InventoryItem content;
    public PlayerInventory playerInventory;
    public Signal raiseItemSignal;
    public BoolValue isOpen;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if(isOpen.initialValue)
        {
            anim.SetBool("open", true);
        }
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Attack") && playerInRange)
        {
            if(!isOpen.initialValue)
            {
                OpenChest();
            }
            else
            {
                ChestOpenning();
            }
          
        }
    }

    public void OpenChest()
    {
        isOpen.initialValue = true;
        contextClueSignal.Raise();
        dialogBox.SetActive(true);
        dialogText.text = content.itemDescription;
        playerInventory.currentItem = content;  
        playerInventory.AddItem(content);
        raiseItemSignal.Raise();
        anim.SetBool("open", true);
    }

    public void ChestOpenning()
    {
        raiseItemSignal.Raise();
        dialogBox.SetActive(false);
        playerInventory.currentItem = null;
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
