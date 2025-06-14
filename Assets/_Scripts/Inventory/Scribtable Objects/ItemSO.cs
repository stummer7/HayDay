using UnityEngine;


public enum ItemType { Tool, Seed, Consumable, Resource }
public enum ToolType { Hoe, Axe, WateringCan }

public abstract class ItemSO : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemType itemType;
    [SerializeField] private GameObject itemPrefab;

    public string ItemName => itemName;
    public Sprite Icon => icon;
    public ItemType Type => itemType;
    public GameObject Prefab => itemPrefab;
}

[CreateAssetMenu(menuName = "Items/Tool")]
public class ToolItemSO : ItemSO
{
    [SerializeField] private int durability;
    [SerializeField] private ToolType toolType; // Hoe, Axe, etc.

    public int Durability => durability;
    public ToolType ToolType => toolType;
}

[CreateAssetMenu(menuName = "Items/Seed")]
public class SeedItemSO : ItemSO
{
    [SerializeField] private float growTime;
    [SerializeField] private HarvestableItemSO harvestItem; // What you get when fully grown

    public float GrowTime => growTime;
    public HarvestableItemSO HarvestableItemSO => harvestItem;
}

[CreateAssetMenu(menuName = "Items/Harvestable")]
public class HarvestableItemSO : ItemSO
{
    [SerializeField] private int sellPrice;
    public int SellPrice => sellPrice;
}
