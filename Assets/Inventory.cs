﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    //public Inventory()
    //{
    //    itemList = new List<Item>();

    //    AddItem(new Item { itemType = Item.ItemType.Methamphetamine, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Ecstasy1, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Ecstasy2, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Ecstasy3, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Ecstasy4, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Hashish, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Methadone, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Morphine, amount = 10 });
    //    AddItem(new Item { itemType = Item.ItemType.Marijuana, amount = 10 });
    //    Debug.Log(itemList.Count);
    //}

    public Inventory(List<Item> items)
    {
        itemList = new List<Item>();
        foreach (Item item in items)
        {
            AddItem(new Item { itemType = item.itemType, amount = item.amount });
        }
    }

    public void AddItem(Item item)
    {
        bool itemAlreadyInInventory = false;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
        }
        if (!itemAlreadyInInventory)
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        Item itemInInventory = null;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount -= item.amount;
                itemInInventory = inventoryItem;
            }
        }
        if (itemInInventory != null && itemInInventory.amount <= 0)
        {
            itemList.Remove(itemInInventory);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
