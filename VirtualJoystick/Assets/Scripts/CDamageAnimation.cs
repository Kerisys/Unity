using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDamageAnimation : MonoBehaviour {
    public string _damageAnimationName;
    public string _dieAnimationName;

    public GameObject _damageUIPrefab;
    public Transform _HUD;

    Animator _animator;
    public bool _isDie; 
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        _isDie = false;
    } 

    void TakeDamage(int damage)
    {
        if (_animator && !_isDie )
        {
            _animator.Play(_damageAnimationName);

            CDamageDisplay _damageDisplay =  Instantiate(_damageUIPrefab, _HUD.position, Quaternion.identity).GetComponent<CDamageDisplay>();

            if (_damageDisplay) _damageDisplay.TakeDamage(damage);

        }
    }

    void Die()
    {
        _isDie = true;
        if (_animator)
        {
            _animator.Play(_dieAnimationName);
        }
    }


    
}
