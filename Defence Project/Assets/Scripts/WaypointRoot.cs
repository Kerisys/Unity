using UnityEngine;
using System.Collections;

public class WaypointRoot : MonoBehaviour {
    public Transform[] GetWayPoints()
    {
        return gameObject.GetComponentsInChildren<Transform>();
    }
}
