using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttack : MonoBehaviour {
    public Transform _attackPos;
    public float _radian;
    public LayerMask _mask;

    public int damage;

    public float _attackSpeed;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        if (_animator)
        {
            _animator.Play("Attack");
        }
    }

    public void OnAttackEvent()
    {
        if (_attackPos == null) return;

        Collider[] colliders = Physics.OverlapSphere(_attackPos.position, _radian, _mask);
        
        foreach(Collider col in colliders)
        {
            col.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnDrawGizmos()
    {
        if (_attackPos)
        {
            Gizmos.DrawWireSphere(_attackPos.position, _radian);
        }
    }


}
