using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndicator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private SpriteRenderer rend;

    private void Awake() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnItemGrabbed(Item item) {
        if (item == null) {
            rend.enabled = false;
            return;
        }
        
        transform.localPosition = item.data.destination;
        rend.enabled = true;
    }
    
    private void OnEnable() {
        playerController.ItemGrabbed += OnItemGrabbed;
    }

    private void OnDisable() {
        playerController.ItemGrabbed -= OnItemGrabbed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
