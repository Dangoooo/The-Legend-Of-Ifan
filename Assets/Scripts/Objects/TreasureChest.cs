using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item content;
    public Inventory playerInventory;
    public Signal raiseItemSignal;
    public bool isOpen;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(!isOpen)
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
        isOpen = true;
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
