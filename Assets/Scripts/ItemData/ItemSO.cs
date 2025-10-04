using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class ItemSO : ScriptableObject {
    public float weight;
    public bool fragile;
    public int estDelivery;
    public TransportType preferredTransport;
    public Vector2 destination;

}

public enum TransportType {
    Air,
    Sea,
    Ground
}
