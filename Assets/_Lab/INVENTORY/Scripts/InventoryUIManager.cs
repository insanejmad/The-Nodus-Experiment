﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{

    public GameObject inventoryBackground;

    public Dictionary<string, GameObject> InventoryUIObjectsDict;

    public GameObject TextPrefab;

    public void Awake()
    {
        InventoryUIObjectsDict = new Dictionary<string, GameObject>();

    }

    public void Initialize()
    {
        PlayerInventory.instance.OnItemAdded += CreateInventoryItem;
        PlayerInventory.instance.OnItemRemoved += DeleteInventoryItem;

        Debug.Log("check");

    }

    public void CreateInventoryItem(Item item)
    {
        GameObject obj = new GameObject();
        obj.transform.SetParent(inventoryBackground.transform,false);
        obj.AddComponent<RectTransform>();
        obj.transform.localPosition = new Vector3(0f,0f,-1f);
        InventoryItemDisplay ItemDisplay = obj.AddComponent<InventoryItemDisplay>();
        ItemDisplay.TextPrefab = TextPrefab;
        ItemDisplay.SetItem(item);
        InventoryUIObjectsDict.Add(item.ItemName, obj);
    }

    public void DeleteInventoryItem(Item item)
    {
        GameObject obj = InventoryUIObjectsDict[item.ItemName];
        InventoryUIObjectsDict.Remove(item.ItemName);
        Destroy(obj);
    }




}
