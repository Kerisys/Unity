using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CMonster : MonoBehaviour {
    public NavMeshAgent _nvAgent;
    public Transform _playerTransform;

	void Start () {
        _nvAgent = GetComponent<NavMeshAgent>();
        if (!_nvAgent) _nvAgent = gameObject.AddComponent<NavMeshAgent>();

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine("TrackingPlayerCoroutine");
	}
	
    IEnumerator TrackingPlayerCoroutine()
    {
        while (true)
        {
            if (_playerTransform) _nvAgent.SetDestination(_playerTransform.position);
            yield return new WaitForSeconds(0.5f);
        }
    }

	void Update () {
		
	}
}
