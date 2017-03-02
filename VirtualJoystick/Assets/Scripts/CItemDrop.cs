using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemDrop : MonoBehaviour {
    public GameObject _dropItemPrefab;

    [Range(0,1)]
    public float _dropProp; // 확률 0~1;

    void Die()
    {
        float randomProp = Random.Range(0f, 1f);

        if (randomProp <= _dropProp)
        {
            Instantiate(_dropItemPrefab, transform.position, transform.rotation);
        }
    }
}
