﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public VirtualJoystick _vjMoving;

    Vector3 _moveDirection = Vector3.zero;
    public float _speed = 10.0f;
    public float _rotSpeed = 180.0f;

    Animator _animator;
    Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if(_vjMoving) _vjMoving.TouchListner += SetMoveDirection;
    }

    public void SetMoveDirection(Vector2 v)
    {
        _moveDirection = new Vector3(v.x, 0, v.y);

        _animator.SetFloat("Speed", _moveDirection.magnitude * _speed);
        transform.LookAt(transform.position + _moveDirection);
        _rigidbody.velocity = _moveDirection * _speed;
    }

    public void Update()
    {

    }

    private void FixedUpdate()
    {   
        transform.Translate(_moveDirection * _speed * Time.fixedDeltaTime,Space.World);
    }
}
