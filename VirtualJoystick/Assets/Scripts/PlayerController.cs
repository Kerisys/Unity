using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public VirtualJoystick vjMoving;

    public VirtualJoystick vjShooting;

    Vector3 moveDirection = Vector3.zero;
    public float speed = 10.0f;
    
    void Start()
    {
        vjMoving.TouchListner += SetMoveDirection;
        vjShooting.TouchListner += SetRotation;
    }

    public void SetMoveDirection(Vector2 v)
    {
        moveDirection.Set(v.x, 0, v.y);
        moveDirection *= speed;
    }

    public void SetRotation(Vector2 v)
    {
        Vector3 dir = new Vector3(v.x,0,v.y);
        transform.LookAt(transform.position + dir);
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDirection*Time.fixedDeltaTime,Space.World);
    }
}
