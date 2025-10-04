using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public event Action<Item> ItemGrabbed;
    private Item currentItem;
    [SerializeField] AudioClip grabSFX;
    [SerializeField] AudioClip boxSFX;
    [SerializeField] AudioClip labelSFX;
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        CurrentItem = null;
    }

    private Item CurrentItem {
        get => currentItem;
        set {
            if (currentItem == value) return;
            currentItem = value;
            ItemGrabbed?.Invoke(currentItem);
            audioSource.PlayOneShot(grabSFX);
        }
    }
    
    public void HandleItemClicked(Item item) {
        if (item.isShipped) return;
        
        if (currentItem == item) {
            ReleaseCurrentItem();
            return;
        }
        
        ReleaseCurrentItem();
        GrabItem(item);
    }

    private void GrabItem(Item item) {
        CurrentItem = item;
        currentItem.transform.position += new Vector3(0f, 0f, 1f);
        currentItem.rb.gravityScale = 0;
    }

    private void HandleLabelHovered(Label label, bool hov) {
        if (!currentItem) return;

        if (hov) {
            label.SetHoverSprite();
        }
        else {
            label.SetIdleSprite();
        }
    }

    private void HandleBoxHovered(Box box, bool hov) {
        if (!currentItem) return;

        if (hov) {
            box.SetHoverSprite();
        }
        else {
            box.SetIdleSprite();
        }
    }
    
    private void HandleLabelClicked(Label label) {
        if (!currentItem) return;
        if (!currentItem.isBoxed) return;

        currentItem.type ^= (int) label.type;
        audioSource.PlayOneShot(labelSFX);
        
        var ptype = PackageFactory.Instance.GetPackageType(currentItem);
        currentItem.SetSprite(ptype.sprite);
    }

    private void HandleBoxClicked(Box box) {
        if (!currentItem) return;

        var clearedType = currentItem.type & ~0b11;
        var newType = clearedType | (int)box.type;
        currentItem.type = newType;
        var mostRightBits = currentItem.type & 0b11;
        currentItem.isBoxed = mostRightBits != 0;
        
        audioSource.PlayOneShot(boxSFX);
        
        var ptype = PackageFactory.Instance.GetPackageType(currentItem);
        currentItem.SetSprite(ptype.sprite);
    }

    private void LateUpdate() {
        if (!currentItem) return;
        var mousePosW = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentItem.rb.position = mousePosW;
    }

    private void ReleaseCurrentItem() {
        if (currentItem) {
            currentItem.transform.position -= new Vector3(0f, 0f, 1f);
            currentItem.rb.gravityScale = 1;
            CurrentItem = null;
        }
    }

    private void OnEnable() {
        Item.Clicked += HandleItemClicked;
        Box.Clicked += HandleBoxClicked;
        Label.Clicked += HandleLabelClicked;
        Box.Hovered += HandleBoxHovered;
        Label.Hovered += HandleLabelHovered;
    }

    private void OnDisable() {
        Item.Clicked -= HandleItemClicked;
        Box.Clicked -= HandleBoxClicked;
        Label.Clicked -= HandleLabelClicked;
        Box.Hovered -= HandleBoxHovered;
        Label.Hovered -= HandleLabelHovered;
    }
}
