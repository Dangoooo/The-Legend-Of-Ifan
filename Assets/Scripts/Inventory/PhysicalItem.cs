using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public InventoryItem thisItem;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            AddItem();
            Destroy(gameObject);
        }
    }

    private void AddItem()
    {
        if(playerInventory && thisItem)
        {
            if(playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberOfItem++;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberOfItem++;
            }
        }
    }
}
