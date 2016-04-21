using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Reset()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage, Vector3 hitPoint)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        gameObject.SetActive(false);
    }
}
