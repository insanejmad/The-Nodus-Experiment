﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TEMPRemoveItemButton : MonoBehaviour
{
    public Button button;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Execute);
    }

    public void Execute()
    {
        PlayerInventory.instance.RemoveItem(item.ItemName);
    }

}
