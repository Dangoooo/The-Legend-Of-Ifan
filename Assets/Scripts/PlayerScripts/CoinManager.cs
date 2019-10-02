using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public Signal receiveCoinSignal;
    public TextMeshProUGUI coinText;
    public Inventory playerInventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoin()
    {
        coinText.text = "X" + playerInventory.numberOfCoins;
    }
}
