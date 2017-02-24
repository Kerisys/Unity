using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCamara : MonoBehaviour,IDragHandler,IPointerDownHandler, IPointerUpHandler {
    public Transform _target;
    public float _rotSpeed = 90f;

    private Vector2 _startPosition;

    void Start () {
        _startPosition = Vector2.zero;
    }

    void RotateCam(Vector2 mousePos)
    {
        Vector2 v = mousePos - _startPosition;
        v.Normalize();

        Quaternion quaternion = _target.rotation ;
        
        Vector3 angle = quaternion.eulerAngles + new Vector3(v.y,-v.x,0) *_rotSpeed * Time.deltaTime;
        if (angle.x <= 0) angle.x = 0;
        if (angle.x >= 80) angle.x = 80;
        quaternion.eulerAngles = angle;

        _target.rotation = quaternion;        
    }


    public void OnPointerDown(PointerEventData data)
    {
        _startPosition = data.position;
        RotateCam(data.position);
    }

    public void OnDrag(PointerEventData data)
    {
        RotateCam(data.position);
    }

    public void OnPointerUp(PointerEventData data)
    {
        RotateCam(data.position);
        _startPosition = Vector2.zero;
    }
}
