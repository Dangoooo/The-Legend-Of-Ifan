using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public InventoryItem currentItem;
    public int numberOfKeys;
    public int numberOfCoins;

    public void AddItem(InventoryItem itemToAdd)
    {
        if (itemToAdd)
        {
            if(!myInventory.Contains(itemToAdd))
            {
                myInventory.Add(itemToAdd);
            }
            itemToAdd.numberOfItem++;
            if(itemToAdd.isKey)
            {
                numberOfKeys++;
            }
        }
    }
}
