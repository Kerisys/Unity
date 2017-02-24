using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven : MonoBehaviour
{
    public ScrollRect invenUI;
    public int slotCount = 50;   
    public int columnCount = 5;
    public bool isOpen;

    public GameObject _invenSlotPrefab;
    
    private void Awake()
    {
        while(invenUI.content.childCount > 0)
        {   // 자녀 삭제
            DestroyImmediate(invenUI.content.GetChild(0).gameObject);
        }        

        CalcLayout();

        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(_invenSlotPrefab, invenUI.content.position, Quaternion.identity, invenUI.content);
        }

        invenUI.gameObject.SetActive(isOpen);
    }

    
    #if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnInventoryToggle();
        }  
    }
    #endif

    /// <summary>
    /// 인벤토리 창 토글
    /// </summary>
    public void OnInventoryToggle()
    {
        isOpen = !isOpen;
        invenUI.gameObject.SetActive(isOpen);
    }
    
    public void CalcLayout()
    {
        GridLayoutGroup grid = invenUI.content.GetComponent<GridLayoutGroup>();
        
        float width = invenUI.content.rect.width - grid.padding.horizontal - grid.spacing.x * (columnCount-1);

        grid.cellSize = Vector2.one * (width / columnCount);  // 정사각형

        int rowCount = Mathf.CeilToInt((float)slotCount / columnCount);
        float height = (grid.cellSize.y+ grid.spacing.y) * rowCount + grid.padding.vertical - grid.spacing.y;

        invenUI.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
}
