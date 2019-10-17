using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int numberOfItem;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use()
    {
        if(numberOfItem > 0)
        {
            thisEvent.Invoke();
        }
    }

    public void ReduceNumber(int amountToReduce)
    {
        numberOfItem -= amountToReduce;
        if(numberOfItem < 0)
        {
            numberOfItem = 0;
        }
    }
}
