using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject inventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private GameObject useButton;
    private InventoryItem currentItem;

    public void SetTextAndButton(string itemDescription, bool buttonActive, InventoryItem newItem)
    {
        currentItem = newItem;
        itemDescriptionText.text = itemDescription;
        useButton.SetActive(buttonActive);
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (inventorySlot && playerInventory.myInventory[i].numberOfItem > 0)
                {
                    GameObject temp = Instantiate(inventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    public void UseButtonClicked()
    {
        if(currentItem)
        {
            currentItem.Use();
            ClearSlots();
            MakeInventorySlots();
            if(currentItem.numberOfItem == 0)
            {
                playerInventory.myInventory.Remove(currentItem);
                SetTextAndButton("", false, null);
            }
        }
    }

    private void ClearSlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
    void OnEnable()
    {
        ClearSlots();
        MakeInventorySlots();
        SetTextAndButton("", false, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
