using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public event Action<float> ScaleChanged;
    private float value = 0.00f;

    private float Value {
        get { return value; }
        set {
            this.value = value; 
            ScaleChanged?.Invoke(value);
        }
    }

    private void Start() {
        Value = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Item")) return;
        var item = other.GetComponent<Item>();
        if (item == null) return;
        Value += item.rb.mass;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Item")) return;
        var item = other.GetComponent<Item>();
        if (item == null) return;
        Value -= item.rb.mass;
    }
}
