using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemDatabase : MonoBehaviour {
    Dictionary<int, CItem> itemDic = new Dictionary<int, CItem>();

    private void Awake()
    {
        CItem[] items = {
            new CItem(0, "Apple",   "Sprites/Item/apple.png"),
            new CItem(1, "Axe",     "Sprites/Item/axe.png"),
            new CItem(2, "Armor",   "Sprites/Item/armor.png"),
            new CItem(3, "Scroll",  "Sprites/Item/scroll.png"),
            new CItem(4, "Potion",  "Sprites/Item/potion.png")
        };
        foreach (CItem item in items)
        {
            itemDic.Add(item.ID, item);
        }
    }

    public CItem FindItem(int id)
    {
        return itemDic[id];
    }

}
