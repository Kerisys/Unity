using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject monster;
    public float spawnTime = 1f;
    public float repeatCount = 10f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
    void Spawn()
    {
        Instantiate(monster, gameObject.transform.position, gameObject.transform.rotation);

        repeatCount--;
        if (repeatCount <= 0)
        {
            CancelInvoke("Spawn");
        }
    }

}
