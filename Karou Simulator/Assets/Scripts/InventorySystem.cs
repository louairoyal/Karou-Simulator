using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject InventoryUI;
    public Image ItemUI;
    public List<Image> ItemPaperUI;
    public static bool isOpenInventory;
    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isOpenInventory)
            {
                isOpenInventory = true;
                InventoryUI.SetActive(true);
                for (int i = 0; i < SaveData.Loot.Count; i++)
                {
                    ItemPaperUI.Add(ItemUI);
                }
            }
            else
            {
                isOpenInventory = false;
                InventoryUI.SetActive(false);
            }
        }
    }
}
