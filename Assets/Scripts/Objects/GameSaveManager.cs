using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{

    public List<ScriptableObject> objects;

    private void OnEnable()
    {
        LoadScriptables();
    }

    /*private void OnDisable()
    {
        SaveScriptables();
    }*/

    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.streamingAssetsPath + $"/{i}.dat");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if(File.Exists(Application.streamingAssetsPath + $"/{i}.dat"))
            {
                FileStream file = File.Open(Application.streamingAssetsPath + $"/{i}.dat", FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }

    public void ResetScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if(File.Exists(Application.streamingAssetsPath + $"/{i}.dat"))
            {
                File.Delete(Application.streamingAssetsPath + $"/{i}.dat");
            }
        }
    }

}
