using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {
    public Boid prefab;
    public Transform target;

    public int flockSize = 20;
    public List<Boid> boids = new List<Boid>();

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < flockSize; i++)
        {
            Boid boid = Instantiate(prefab, transform.position, transform.rotation) as Boid;
            boid.transform.parent = transform;
            boid.transform.localPosition = new Vector3(
                            Random.value * GetComponent<Collider>().bounds.size.x,
                            Random.value * GetComponent<Collider>().bounds.size.y,
                            Random.value * GetComponent<Collider>().bounds.size.z) - GetComponent<Collider>().bounds.extents;
            boid.controller = this;
            boids.Add(boid);
        }
    }
}
