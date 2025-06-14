using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private Sprite icon;

    public GameObject GameObject => gameObject;
    public Sprite Icon => icon;
    public string ItemName => itemName;

    public ItemData(string itemName, GameObject gameObject, Sprite icon)
    {
        this.itemName = itemName;
        this.gameObject = gameObject;
        this.icon = icon;
    }

}
