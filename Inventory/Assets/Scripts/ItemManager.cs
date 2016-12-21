using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public List<Sprite> imageList;
    
    public Sprite GetImage(int index)
    {
        return imageList[index];
    }

    public int Length()
    {
        return imageList.Count;
    }
}
