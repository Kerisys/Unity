using System;
using UnityEngine;

using UnityEngine.EventSystems; // UGUI Interface

public class VirtualJoystick :
    MonoBehaviour, IDragHandler,
    IBeginDragHandler, IEndDragHandler,
    IPointerDownHandler, IPointerUpHandler
{
    public RectTransform backboard;
    public RectTransform stick;
    public Action<Vector2> TouchListner;

    public float radian; // Stick이 움직일수 있는 반경
    public bool isJoystickLock = false;

    bool isMoving = false;
    Vector2 backBoardOriginPosition, stickOriginPosition;
    Vector2 startPosition;

    void Start()
    {
        // 원점 보존
        backBoardOriginPosition = backboard.anchoredPosition;
        stickOriginPosition = stick.anchoredPosition;
        
        isMoving = false;
        startPosition = backBoardOriginPosition;
    }
    

    // 터치 구현부
    private void BeginTouch(ref PointerEventData data)
    {
        if (isJoystickLock)
        {
            isMoving = true;
            startPosition = backBoardOriginPosition;
        }
        else
        {
            isMoving = true;
            startPosition = data.position;
            backboard.position = data.position;
            stick.position = data.position;
        }
    }

    private void DragTouch(ref PointerEventData data)
    {
        if (isMoving)
        {
            // stick.position = startPosition + Vector2.ClampMagnitude(data.position - startPosition, size);
            Vector2 moveDirection = Vector2.ClampMagnitude(data.position - startPosition, radian);
            stick.position = startPosition + moveDirection;

            if (TouchListner != null)
            {
                moveDirection = moveDirection / radian; // 0~1 사이즈로 표현
                TouchListner(moveDirection);
            }
        }
    }

    private void EndTouch(ref PointerEventData data)
    {
        isMoving = false;

        backboard.anchoredPosition = backBoardOriginPosition;
        stick.anchoredPosition = stickOriginPosition;    

        startPosition = Vector2.zero;
        if (TouchListner != null)
        {
            TouchListner(Vector2.zero);
        }
    }

    // 터치 이벤트 매칭
    public void OnBeginDrag(PointerEventData data)
    {
        BeginTouch(ref data);
    }

    public void OnEndDrag(PointerEventData data)
    {
        EndTouch(ref data);
    }

    public void OnPointerDown(PointerEventData data)
    {
        BeginTouch(ref data);
    }

    public void OnDrag(PointerEventData data)
    {
        DragTouch(ref data);
    }

    public void OnPointerUp(PointerEventData data)
    {
        EndTouch(ref data);
    }
}
