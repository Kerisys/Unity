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

        Reset();
    }

    private void Reset()
    {
        _nvAgent.Resume();
        StartCoroutine("TrackingPlayerCoroutine");
    }

    IEnumerator TrackingPlayerCoroutine()
    {
        while (_playerTransform)
        {
            _nvAgent.SetDestination(_playerTransform.position);

            if(_nvAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                SendMessage("PlayAttackAnimation");
            }

            yield return new WaitForSeconds(trackingTime);
        }
    }

    void Die()
    {
        _nvAgent.Stop();
        StopAllCoroutines();
    }


}
