using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public static event Action<Box> Clicked;
    public static event Action<Box, bool> Hovered;
    private SpriteRenderer rend;
    [SerializeField] private Sprite hoverSprite;
    private Sprite idleSprite;
    public Type type;
    
    public enum Type {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    
    private void Awake() {
        rend = GetComponent<SpriteRenderer>();
        idleSprite = rend.sprite;
    }

    private void OnMouseEnter() {
        Hovered?.Invoke(this, true);
    }

    private void OnMouseExit() {
        Hovered?.Invoke(this, false);
    }

    private void OnMouseDown() {
        Clicked?.Invoke(this);
    }

    public void SetIdleSprite() {
        rend.sprite = idleSprite;
    }

    public void SetHoverSprite() {
        rend.sprite = hoverSprite;
    }
}
