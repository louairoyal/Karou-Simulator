using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static Dictionary<string, int> Loot = new Dictionary<string, int>();
    public static void addLoot(string LootName,int quantity)
    {
        if (Loot.ContainsKey(LootName))
        {
            Loot[LootName] += quantity;
        }
        else
        {
            Loot.Add(LootName, quantity);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < Loot.Count; i++)
            {
                Debug.Log(Loot.ElementAt(i));
            }
        }
    }
}