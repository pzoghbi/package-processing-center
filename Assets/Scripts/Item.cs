using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public static event Action<Item> Clicked;
    public ItemSO data;
    public Rigidbody2D rb;
    public PolygonCollider2D coll;
    public int type = 0; // 0 = invalid
    public bool isBoxed = false;
    public bool isLabeled = false;
    public bool isShipped = false;
    private SpriteRenderer rend;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        rb.mass = data.weight;
    }

    private void OnMouseDown() {
        Clicked?.Invoke(this);
    }

    public void SetSprite(Sprite sprite) {
        rend.sprite = sprite;
        Destroy(coll);
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
