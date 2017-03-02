using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
    public int _id;
    public int _count;
    public Image _itemImage;
    public Text _itemCountText;

    private void Awake()
    {
        ItemDB itemDB = FindObjectOfType<ItemDB>();

         _itemImage.sprite = itemDB.FindItem(_id).Sprite;

        _itemCountText.text = (_count==0 ? string.Empty : _count.ToString() ); 
    }

    public void AddItem(int count)
    {
        _count += count;
        _itemCountText.text = _count.ToString();
    }

    public void SetItem(int id, int count)
    {     
        ItemDB itemDB = FindObjectOfType<ItemDB>();
        if (itemDB == null) Debug.Log("ItemSlot : itemDB is NUll");

        Item item = itemDB.FindItem(id);

        if (item == null) return;

        _id = id;
        _count = count;

        _itemImage.sprite = item.Sprite;        
        _itemCountText.text = _count.ToString();        
    }
}
