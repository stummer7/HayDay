using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private int selectedIndex = 0;

    void Update()
    {
        HandleScrollInput();
        HandleKeyInput();
    }

    void HandleScrollInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0) SelectSlot((selectedIndex + 1) % 9);
        if (scroll < 0) SelectSlot((selectedIndex + 8) % 9);
    }

    void HandleKeyInput()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                SelectSlot(i);
        }
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;
        // Trigger UI update or equip logic
    }
}

