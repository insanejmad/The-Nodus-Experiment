﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEMP


//Singleton Manager, holds info on which items are in the inventory
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance = null;

    public List<Item> ItemList;

    public int maxItems = 2;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ItemList = new List<Item>(maxItems);

    }

    public bool ContainsItem(string name)
    {
        foreach(var item in ItemList)
        {
            if(item.ItemName == name)
            {
                return true;
            }
        }
        return false;
    }

    public Item GetItem(string name)
    {

        foreach (var item in ItemList)
        {
            if (item.ItemName == name)
            {
                return item;
            }

        }
        Debug.Log("ERROR : Tried getting item that wasn't in the inventory");
        return null;
    }

    public void AddItem(Item it)
    {
        if(ItemList.Count < maxItems)
        {
            ItemList.Add(it);
        }
        else
        {
            Debug.Log("Inventory Full");
        }
    }

    public void RemoveItem(string name)
    {
        Item item = GetItem(name);
        ItemList.Remove(item);
    }
}
