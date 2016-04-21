using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public int damage = 10;
    public float speed = 2.0f;
    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.tag == "Enemy")
        {
            // ... the player is in range.
            other.GetComponent<EnemyHealth>().TakeDamage(damage, other.transform.position);
            DestroyThis();
        }
    }

    // Use this for initialization
    void Start () {
        Invoke("DestroyThis", 5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime* speed);
	}
    void DestroyThis()
    {
        DestroyObject(gameObject);
    }
}
