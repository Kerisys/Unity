using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenUI : MonoBehaviour {
    public GameObject _invenSlotPrefab;
    public GameObject _itemSlotPrefab;
    public ScrollRect _scrollRect;
    public int _slotCount;
    public int _columnCount;
    private List<GameObject> _slotList = new List<GameObject>();
    public List<ItemSlot> _itemList = new List<ItemSlot>();
    public bool _isOpen;

    public bool IsFull
    {
        get
        {
            return _itemList.Count >= _slotCount;
        }
    }

	void Start () {
        // Slot을 붙일 위치
        RectTransform _slotHolder = _scrollRect.content;

        // 에디터에서 붙여둔 Slot 전부 삭제
        for (int i = 0; i < _slotHolder.childCount; i++)
        {
            Destroy(_slotHolder.GetChild(i).gameObject);
        }

        // _slotCount만큼 새로 추가
        for (int i=0; i< _slotCount; i++)
        {
            _slotList.Add(Instantiate(_invenSlotPrefab, Vector3.zero, Quaternion.identity, _slotHolder));
        }
        
        CalcLayout();

        ShowInventory(_isOpen);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnToggleInventory();
        }
	}

    public void OnToggleInventory()
    {
        _isOpen = !_isOpen;
        ShowInventory(_isOpen);
    }

    void ShowInventory(bool isOpen)
    {
        _scrollRect.gameObject.SetActive(isOpen);
    }

    /// <summary>
    /// grid의 cellSize 재설정. content의 Height 재설정
    /// </summary>
    void CalcLayout()
    {
        RectTransform content = _scrollRect.content;

        GridLayoutGroup grid = content.GetComponent<GridLayoutGroup>();

        float width = content.rect.width - grid.padding.horizontal  // 테두리 padding 제거
                        - grid.spacing.x * (_columnCount - 1);      // spacing 제거

        // 슬롯 사이즈. 정사각형
        grid.cellSize = new Vector2(width / _columnCount, width / _columnCount);
        
        int rowCount = Mathf.CeilToInt((float)_slotCount / _columnCount);   // 행 갯수를 구함        
        float height = grid.cellSize.y * rowCount           // cell들의 합
                        + grid.padding.vertical             // 가장자리 간격
                        + grid.spacing.y * (rowCount-1);    // cell들 사이 간격

        // 높이 값 재설정
        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
    
    public void AddItem(int id, int count)
    {
        // 같은게 있으면 Count만 증가
        for(int i=0;i<_itemList.Count;i++)
        {
            ItemSlot item = _itemList[i];
            if(item._id == id)
            {
                item.AddItem(count);
                
                return;
            }
        }

        // 같은게 없을 경우 새로 추가

        if (IsFull) return; // 인벤이 가득차 있으면 패스
        
        foreach(GameObject invenSlot in _slotList)
        {   // 빈 슬롯을 찾아서
            if (invenSlot.transform.childCount == 0)
            {
                ItemSlot item = Instantiate(_itemSlotPrefab, invenSlot.transform.position, Quaternion.identity, invenSlot.transform).GetComponent<ItemSlot>();
                item.SetItem(id, count);
                _itemList.Add(item);
                return;
            }
        }
    }

}
