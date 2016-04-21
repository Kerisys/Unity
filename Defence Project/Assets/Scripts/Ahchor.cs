using UnityEngine;
using System.Collections;

public class Ahchor : MonoBehaviour {
    public Spawn spawnCompnent;
    public GameObject[] EnemyPool;

    public GameObject Arrow;
    public Transform ShootPoint;

    public float AttackDistance = 2.0f;
    public float AttackDelay = 1.0f;
    float lastAttackTime = 0.0f;

	// Use this for initialization
	void Start () {
        if (spawnCompnent == null || EnemyPool == null)
            Debug.Break();
        EnemyPool = spawnCompnent.GetEnemys();
        lastAttackTime = Time.time;
	}
	
	void FixedUpdate () {
        if (lastAttackTime + AttackDelay <= Time.time)
        {
            nearestAttack();
            lastAttackTime = Time.time;
        }
	}

    void nearestAttack ()
    {
        GameObject nearestObject = null; // 가장 가까운 오브젝트;
        float nearestDistance = AttackDistance*AttackDistance;  // 가장 까까운 거리
        foreach(GameObject enemy in EnemyPool)
        {
            if( enemy.activeInHierarchy)
            {
                float sqrEnmyDistance = Vector3.SqrMagnitude(enemy.transform.position-transform.position /* +(Vector3.up*enemy.GetComponent<NavMeshAgent>().height/2.0f) */ );
                if ( sqrEnmyDistance <= nearestDistance)
                {
                    nearestObject = enemy;
                    nearestDistance = sqrEnmyDistance;
                }
            }
        }
        if (nearestObject)
        {
            transform.LookAt(nearestObject.transform);

            if (Arrow)
            {
                Instantiate(Arrow, ShootPoint.position, Quaternion.LookRotation(nearestObject.transform.position-ShootPoint.position /*  + (Vector3.up * nearestObject.GetComponent<NavMeshAgent>().height / 2.0f) */ ));
            }
        }
    }

}
