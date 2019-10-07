using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public PowerUp thisLoot;
    public int createChance;
}


[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;
    public PowerUp CreateLoot()
    {
        int sumChance = 0;
        int currentChance = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            sumChance += loots[i].createChance;
            if(currentChance < sumChance)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}
