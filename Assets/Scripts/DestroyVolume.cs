using UnityEngine;

public class DestroyVolume : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D other) {
        var item =  other.GetComponent<Item>();
        if (item == null) return;
        Destroy(item.gameObject);
        gameManager.Score -= 300;
        gameManager.PlayBadSFX();
    }
}
