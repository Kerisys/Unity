using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform _target;
    public Vector3 _offset;

    public float _smootingTime = 5f;

    public void Update()
    {

    }

    private void LateUpdate()
    {
        if (_target)
        {
            Vector3 targetCamPos = _target.position + _offset;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, _smootingTime * Time.deltaTime);
        }
    }
}
