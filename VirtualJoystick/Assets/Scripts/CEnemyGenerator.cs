using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyGenerator : MonoBehaviour {
    public Transform[] _genPoints;
    public GameObject[] enemys;
    public float _regenTime;

    void Start () {
        StartCoroutine("RegenCoroutine");
	}
	
    IEnumerator RegenCoroutine()
    {
        while (true)
        {
            Transform genPoint = _genPoints[Random.Range(0, _genPoints.Length)];

            if (genPoint.childCount == 0)
            {
                Instantiate(enemys[Random.Range(0, enemys.Length)], genPoint.position, Quaternion.identity, genPoint);
            }else
            {
                yield return null;
                continue;
            }


            yield return new WaitForSeconds(_regenTime);
        }
    }

    private void OnDrawGizmos()
    {
        foreach(Transform point in _genPoints)
        {
            Gizmos.DrawWireSphere(point.position, 1f);
        }
    }

}
