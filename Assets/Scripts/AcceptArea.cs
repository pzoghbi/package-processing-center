using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        var item = other.GetComponent<Item>();
        if (!item) return;
        if (!item.isBoxed) return;
        if (item.rb.gravityScale == 0) return;
        item.isShipped = true;
    }
}
