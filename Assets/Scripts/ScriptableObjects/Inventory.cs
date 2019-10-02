using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int numberOfCoins; 
    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
            items.Add(itemToAdd);
        }
        else
        {
            if(!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
