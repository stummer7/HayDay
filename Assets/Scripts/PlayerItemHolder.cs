using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    public Transform handTransform; // Assign in Inspector
    private GameObject currentHeldItem;

    public void EquipItem(ItemData itemData)
    {
        // Remove previous item
        if (currentHeldItem != null)
        {
            Destroy(currentHeldItem);
        }

        // Instantiate and attach new item
        if (itemData != null && itemData.GameObject != null)
        {
            currentHeldItem = Instantiate(itemData.GameObject, handTransform);
            currentHeldItem.transform.localPosition = Vector3.zero;
            currentHeldItem.transform.localRotation = Quaternion.identity;
        }
    }
}
