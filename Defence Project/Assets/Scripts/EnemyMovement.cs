using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public WaypointRoot waypoint;
    Transform[] waypoints;
    public float CollisionRadius = 0.5f;
    int way_index=0;
    int way_length;
    bool b_isHitRadius;

    NavMeshAgent nav;

    void Awake () {
        //waypoint = GameObject.FindGameObjectWithTag("WaypointRoot").GetComponent<Waypoint>();
        waypoints = waypoint.GetWayPoints();
        way_length = waypoints.Length;
    }

    public void Reset()
    {
        way_index = 0;
        b_isHitRadius = false;
        transform.position = waypoints[0].position;
    }

	// Use this for initialization
	void Start () {
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
        nav = GetComponent<NavMeshAgent>();
        if (!nav)
        {
            gameObject.SetActive(false);
        }
        if (Vector3.Distance(gameObject.transform.position, waypoints[way_index].position) <= CollisionRadius)
        {   // 웨이포인트 근처
            if (!b_isHitRadius)
            {   // 최초 도착시에 다음 위치를 지정
                b_isHitRadius = true;

                way_index = (way_index + 1) % way_length;
            }
        }else
        {   // 웨이포인트를 벗어나면 다시 검사
            b_isHitRadius = false;
        }

        if (nav == null) return;

        nav.SetDestination(waypoints[way_index].position);
    }
}
