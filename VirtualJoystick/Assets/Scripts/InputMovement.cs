using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour {
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

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _animator.SetFloat("Speed", _moveDirection.magnitude * _speed);

        transform.LookAt(transform.position + _moveDirection);
        _rigidbody.velocity = _moveDirection * _speed;
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _speed * Time.fixedDeltaTime, Space.World);
    }
}
