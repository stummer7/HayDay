using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject hotbarUI;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private Player player;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hotbarUI.SetActive(isOpen);
            crossHair.SetActive(isOpen);
            isOpen = !isOpen;
            inventoryUI.SetActive(isOpen);

            if (isOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.IsScreenLocked = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.IsScreenLocked = false;
            }
        }
    }
    void Start()
    {
        inventoryUI.SetActive(isOpen);
    }
}
