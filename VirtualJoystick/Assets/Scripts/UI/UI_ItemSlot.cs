using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour {
    Image _image;
    public Text _countText;
    public int _itemCount;
        
    public CItem item;

    private void Awake()
    {
        _image = GetComponent<Image>();
        //if (item == null)   item = CItem.NonItem;
    }

    void Start () {
        if ( item ) _image.sprite = item.Sprite;
	}

    void Update()
    {
        if (_countText) _countText.text = _itemCount.ToString();
    }
    
}
