using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOld : MonoBehaviour
{
    [SerializeField] private List<ItemData> items = new(36);

    public List<ItemData> Items => items;

    public void Start()
    {
    }

    public void AddItem(ItemData itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(ItemData itemToRemove)
    {
        items.Remove(itemToRemove);
    }
    

}
