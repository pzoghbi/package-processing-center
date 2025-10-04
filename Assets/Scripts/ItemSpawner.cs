using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private float spawnDelay = 5;
    
    public void StartSpawning() {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine() {
        SpawnRandomObject();
        yield return new WaitForSecondsRealtime(spawnDelay);
        StartSpawning();
    }

    private void SpawnRandomObject() {
        if (items.Count <= 0) return;
        Instantiate(
            items[Random.Range(0, items.Count)], 
            transform.position, 
            Quaternion.identity
        );
    }
}
