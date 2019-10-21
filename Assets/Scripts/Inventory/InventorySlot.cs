using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public  TextMeshProUGUI numberOfItemText;
    public Image itemImage;
    //public Sprite itemSprite;
   // public int numberOfItem;
   // public string itemDescription;
    private InventoryItem thisItem;
    private InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem)
        {
            itemImage.sprite = newItem.itemSprite;
            numberOfItemText.text = "" + newItem.numberOfItem;
        }
    }

    public void ClickedOn()
    {
        if(thisItem)
        {
            thisManager.SetTextAndButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
