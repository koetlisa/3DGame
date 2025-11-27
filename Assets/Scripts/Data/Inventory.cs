using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();
    public int maxSlots = 20;

    // Add an item to the inventory.
    public bool AddItem(Item item, int amount)
    {
        // Look for an existing stack first.
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.amount < item.maxStack)
            {
                slot.amount += amount;
                return true;
            }
        }

        // If no stack found, add new slot
        if (slots.Count < maxSlots)
        {
            slots.Add(new InventorySlot(item, amount));
            return true;
        }

        Debug.Log("Inventory full!");
        return false;
    }
}
