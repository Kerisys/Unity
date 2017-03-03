using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHealth : MonoBehaviour {
    public int _hp;
    private int _maxHP;
    private bool _isDie;

    public Image _hpBar;
    private float _hpRatio;

    void Awake()
    {
        _maxHP = _hp;
        _hpRatio = 1f /_maxHP;

        Reset();
    }

    protected void Reset()
    {
        _hp = _maxHP;

        if (_hpBar) _hpBar.fillAmount = 1f;

        _isDie = false;
    }    

    protected void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hpBar) _hpBar.fillAmount = _hp * _hpRatio;

        if (_hp <= 0 && !_isDie)
        {
            SendMessage("Die", SendMessageOptions.DontRequireReceiver);

            _isDie = true;
        }
    }

}
