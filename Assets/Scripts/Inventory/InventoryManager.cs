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
                if (inventorySlot)
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
        }
    }
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
