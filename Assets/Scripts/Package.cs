using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour {
    public float weight;
    public bool fragile;
    public Sprite sprite {
        get => rend.sprite; 
        set => rend.sprite = value;
    }
    
    [SerializeField] public PackageType packagetype;
    private SpriteRenderer rend;

    private void Awake() {
        rend = GetComponent<SpriteRenderer>();
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