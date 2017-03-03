using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPickupItem : MonoBehaviour {
    public InvenUI inven;

    private void OnTriggerEnter(Collider other)
    {
        GameItem item = other.GetComponent<GameItem>();
        if (item == null) return;

        inven.AddItem(item.ID, item.Count);

        Destroy(other.gameObject);
    }
}
