using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHealth : MonoBehaviour {
    public int _hp;
    private int _maxHP;
    private float _hpRatio;

    public Image _hpBar;
    
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
    }    

    protected void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hpBar) _hpBar.fillAmount = _hp * _hpRatio;

        if (_hp <= 0) SendMessage("Die");
    }
}
