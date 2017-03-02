using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int ID;
    public string Name;
    public Sprite Sprite;
}

public class ItemDB : MonoBehaviour {
    public List<Item> _itemList = new List<Item>();
        
    public Item FindItem(int id)
    {
        foreach (Item item in _itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }
}
