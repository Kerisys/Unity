using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CTrackingPlayer : MonoBehaviour {
    NavMeshAgent _nvAgent;
    Transform _playerTransform;

    public float trackingTime = 0.5f;

    void Start()
    {
        _nvAgent = GetComponent<NavMeshAgent>();

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine("TrackingPlayerCoroutine");
    }

    IEnumerator TrackingPlayerCoroutine()
    {
        while (true)
        {
            if (_playerTransform) _nvAgent.SetDestination(_playerTransform.position);

            yield return new WaitForSeconds(trackingTime);
        }
    }
}
