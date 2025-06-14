using UnityEngine;


public interface IInventory
{
    bool AddItem(ItemSO item, int quantity);
    bool RemoveItem(ItemSO item, int quantity);
    InventorySlot[] GetSlots();
}

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;
    public int quantity;

    public bool IsEmpty => item == null;
}

public class Inventory : MonoBehaviour, IInventory
{
    [SerializeField] private int totalSlots = 36;
    [SerializeField] private int hotbarSize = 9;

    private InventorySlot[] slots;

    void Awake()
    {
        slots = new InventorySlot[totalSlots];
        for (int i = 0; i < slots.Length; i++)
            slots[i] = new InventorySlot();
    }

    public InventorySlot[] GetSlots() => slots;

    public bool AddItem(ItemSO item, int quantity)
    {
        // Try to stack first, then find empty
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.quantity += quantity;
                return true;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.quantity = quantity;
                return true;
            }
        }

        return false; // Inventory full
    }



    public bool RemoveItem(ItemSO item, int quantity)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.quantity >= quantity)
            {
                slot.quantity -= quantity;
                if (slot.quantity <= 0)
                    slot.item = null;
                return true;
            }
        }

        return false;
    }
}
