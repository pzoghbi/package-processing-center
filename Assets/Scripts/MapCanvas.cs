using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapCanvas : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    TMP_Text tmp;

    private void Awake() {
        tmp = GetComponent<TMP_Text>();
        tmp.text = "";
    }

    private void OnItemGrabbed(Item item) {
        if (item == null) {
            tmp.text = "";
            return;    
        }
        
        var est = item.data.estDelivery;
        tmp.text = $"EST. {est} DAYS";
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
