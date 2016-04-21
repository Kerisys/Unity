using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject[] objectPool;
    public float spawnTime = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("NewSpawn", 0f, spawnTime);
	}
	
    void NewSpawn ()
    {
        foreach(GameObject obj in objectPool)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                obj.GetComponent<EnemyMovement>().Reset();
                obj.GetComponent<EnemyHealth>().Reset();
                return;
            }
        }
    }
    public GameObject[] GetEnemys()
    {
        return objectPool;
    }
}
