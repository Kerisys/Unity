using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    public BoidController controller;
    
    private Vector3 velocity;
    private Vector3 dir;
    public float moveSpeed;
    public float rotateSpeed;

    public float NEIGHBOUR_RADIUS;
    public float DESIRED_SEPARATION;

    // Use this for initialization
    void Start () {
        StartCoroutine(Calc());
    }
	
    private void FixedUpdate()
    {
        velocity = Vector3.Slerp(velocity, dir, rotateSpeed * Time.fixedDeltaTime);
        transform.Translate(velocity * moveSpeed *Time.fixedDeltaTime);
    }

    IEnumerator Calc()
    {
        while (true)
        {
            Vector3 AvgPosition, AvgVelocity, AvgDistance;
            AvgPosition = -transform.position;
            AvgVelocity = -velocity;
            AvgDistance = Vector3.zero;
            int flockSize = -1;
            int serpSize = -1   ;
            if (controller.boids.Count > 0)
            {
                foreach (Boid boid in controller.boids)
                {
                    if (Vector3.Distance(transform.position, boid.transform.position) <= NEIGHBOUR_RADIUS)
                    {
                        AvgPosition += boid.transform.position;
                        AvgVelocity += boid.velocity;
                        flockSize++;
                        float distance = Vector3.Distance(transform.position, boid.transform.position);
                        if (distance <= DESIRED_SEPARATION)
                        {
                            Vector3 v = transform.position - boid.transform.position;
                            v.Normalize();

                            // 거리에 반비례하여 세기가 강함
                            if (v.x != 0) v.x = distance / v.x;
                            if (v.y != 0) v.y = distance / v.y;
                            if (v.z != 0) v.z = distance / v.z;

                            AvgDistance += v;
                            serpSize++;
                        }   
                    }
                }
                if (flockSize > 0)
                {
                    AvgPosition = AvgPosition / flockSize - transform.position;
                    AvgVelocity = AvgVelocity / flockSize;
                    if (serpSize > 0) AvgDistance = AvgDistance / serpSize;
                }

                Vector3 follow = controller.target.position - transform.position;

                dir = AvgDistance + AvgVelocity + AvgPosition + follow*0.01f;

                dir.Normalize();
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, velocity);
    }

}
