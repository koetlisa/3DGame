using UnityEngine;

public enum ItemType
{
    Tool,
    Seed,
    Resource,
    Food,
    Weapon,
    Default
}

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public int maxStack = 99;
}