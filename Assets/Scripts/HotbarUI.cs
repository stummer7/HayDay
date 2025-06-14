using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] public Image[] slotItems; // Assign in Inspector
    private InventoryOld inventory;
    public Image[] selectionBorders;       // Highlight borders
    public Color selectedColor = Color.yellow;
    public Color normalColor = Color.white;
    private int selectedIndex = 0;

    public InventoryOld Inventory { get { return inventory; } set { inventory = value; } }

    void Start()
    {
        inventory = FindObjectOfType<InventoryOld>(); // Or assign directly
        UpdateHotbar();
        UpdateSelectionVisuals();
        SelectSlot(0);
    }

    void Update()
    {
        // Number keys 1-5 to switch slots
        for (int i = 0; i < slotItems.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }
    }

    public void UpdateHotbar()
    {
        for (int i = 0; i < slotItems.Length; i++)
        {
            if (i < inventory.Items.Count)
            {
                slotItems[i].sprite = inventory.Items[i].Icon;
                slotItems[i].enabled = true;
            }
            else
            {
                slotItems[i].sprite = null;
                slotItems[i].enabled = false;
            }
        }
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;
        UpdateSelectionVisuals();

        ItemData selectedItem = GetSelectedItem();

        // Notify player
        PlayerItemHolder holder = FindObjectOfType<PlayerItemHolder>();
        if (holder != null)
        {
            holder.EquipItem(selectedItem);
        }

        // Optional: Tell inventory or player what the selected item is
        Debug.Log("Selected item: " + GetSelectedItem()?.ItemName);
    }

    void UpdateSelectionVisuals()
    {
        for (int i = 0; i < selectionBorders.Length; i++)
        {
            selectionBorders[i].color = (i == selectedIndex) ? selectedColor : normalColor;
        }
    }

    public ItemData GetSelectedItem()
    {
        if (selectedIndex < inventory.Items.Count)
            return inventory.Items[selectedIndex];
        return null;
    }
}
