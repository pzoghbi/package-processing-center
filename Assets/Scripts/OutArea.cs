using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutArea : MonoBehaviour {
    public static event Action<TransportType, Item, ItemSO> ItemDispached; 
    public TransportType transportType;

    private void OnTriggerEnter2D(Collider2D other) {
        var item = other.GetComponent<Item>();
        if (item == null) return;
        ItemDispached?.Invoke(transportType, item, item.data);
        Destroy(item.gameObject);
    }
}
