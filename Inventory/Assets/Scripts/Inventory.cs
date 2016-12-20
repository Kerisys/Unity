using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent(typeof(GridLayoutGroup))]

public class Inventory : MonoBehaviour
{
    GridLayoutGroup grid;

    public int columnCount = 5;
    public int padding = 5;

    public int itemCount = 37;

    public GameObject itemPrefab;

    public ItemManager itemMng;
    public List<GameObject> itemList = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject go in itemList)
        {
            GameObject.DestroyImmediate(go);
        }

        for(int i = 0; i < itemCount; i++)
        {
            //GameObject go = GameObject.Instantiate(itemPrefab);
            GameObject ge = PrefabUtility.InstantiatePrefab(itemPrefab) as GameObject;
            ge.transform.parent = transform;
            ge.transform.GetChild(0).GetComponent<Image>().sprite = itemMng.GetImage(Mathf.FloorToInt(Random.value * itemMng.Length()));
            itemList.Add(ge);
        }

        CalcGridLayout();
    }

    public void CalcGridLayout()
    {
        grid = GetComponent<GridLayoutGroup>();

        grid.padding = new RectOffset(padding, padding, padding, padding);

        grid.spacing = new Vector2(padding, padding);

        float width = GetComponent<RectTransform>().rect.width - padding * (columnCount + 1);

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, grid.cellSize.y * Mathf.CeilToInt(itemCount / columnCount));

        grid.cellSize = new Vector2(width / columnCount, width / columnCount);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
