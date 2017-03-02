using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDamageDisplay : MonoBehaviour {
    public Text _text;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _text.text = damage.ToString();
        _animator.Play("DamageUPDestoy");
    }

    public void DestroyDisplay()
    {
        Destroy(gameObject);
    }
}
