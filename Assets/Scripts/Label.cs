using System;
using UnityEngine;

public class Label : MonoBehaviour {
    public static event Action<Label> Clicked;
    public static event Action<Label, bool> Hovered;
    private SpriteRenderer rend;
    [SerializeField] private Sprite hoverSprite;
    private Sprite idleSprite;
    
    public enum Type {
        None = 0,
        Priority = 8,
        Fragile = 4
    }

    public Type type;
    
    
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
    
    public void SetHoverSprite() {
        rend.sprite = hoverSprite;
    }

    public void SetIdleSprite() {
        rend.sprite = idleSprite;
    }
}