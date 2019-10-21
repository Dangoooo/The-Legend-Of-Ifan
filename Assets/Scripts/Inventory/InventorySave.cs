using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class InventorySave : MonoBehaviour
{
    public PlayerInventory playerInventory;
    private void OnEnable()
    {
        playerInventory.myInventory.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
        playerInventory.myInventory.Clear();
    }

    public void SaveScriptables()
    {
        ResetScriptables();
        for (int i = 0; i < playerInventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.streamingAssetsPath + $"/{i}.inv");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(playerInventory.myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        int i = 0;
        while (File.Exists(Application.streamingAssetsPath + $"/{i}.inv"))
        {
            var temp = ScriptableObject.CreateInstance<InventoryItem>();

            FileStream file = File.Open(Application.streamingAssetsPath + $"/{i}.inv", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
            file.Close();
            playerInventory.myInventory.Add(temp);
            i++;
        }

    }

    public void ResetScriptables()
    {
        int i = 0;
        while (File.Exists(Application.streamingAssetsPath + $"/{i}.inv"))
        {
            File.Delete(Application.streamingAssetsPath + $"/{i}.inv");
            i++;
        }
    }
}
