using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryOld inventory;
    [SerializeField] private ItemData[] slots;


    void Start()
    {
        UpdateInventory();
    }

    void Update()
    {

    }

    void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Items.Count)
            {
                slots[i].GameObject.SetActive(true);
                //slots[i].UpdateItemDisplay(inventory.Items[i].itemType.icon, i);
            }
            else
            {
                slots[i].GameObject.SetActive(false);
            }
        }
    }
}
