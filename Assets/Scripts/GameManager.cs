using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private Sprite markGood;
    [SerializeField] private Sprite markBad;
    [SerializeField] private Sprite markOk;
    [SerializeField] private SpriteRenderer mark;
    AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip incorrectSFX;
    [SerializeField] private AudioClip okSFX;
    public static event Action<int> ScoreChanged;
    private int score = 0;

    public int Score {
        get { return score; }
        set {
            score = value;
            ScoreChanged?.Invoke(score);
        }
    }

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        itemSpawner.StartSpawning();     
        mark.gameObject.SetActive(false);
        Score = 0;
    }

    private void HandleItemDispatched(TransportType tt, Item i, ItemSO idata) {
        int points = 0;
        points += tt == idata.preferredTransport ? 1 : 0; // Transport
        
        // Box size
        if (GetType(idata.weight) == (i.type & 0b11)) {
            points += 1;
        }

        //// Deduct points
        // Fragile
        var fragValue = (i.type >> 2) & 1;
        var realFrag = idata.fragile ? 1 : 0;
        if (realFrag != fragValue) {
            points -= 1;
        }
            
        // Priority
        var prio = (i.type >> 3) & 1;
        if (idata.estDelivery <= 3) {
            if (prio != 1) {
                points -= 1;
            }
        }
        else {
            if (prio != 0)  {
                points -= 1;
            }
        }
        
        if (!i.isBoxed) points = 0;

        Sprite sprite;
        if (points <= 0) {
            sprite = markBad;
            audioSource.PlayOneShot(incorrectSFX);
        } else if (points is > 0 and < 2) {
            sprite = markOk;
            audioSource.PlayOneShot(okSFX);
        }
        else {
            sprite = markGood;
            audioSource.PlayOneShot(correctSFX);
        }

        Score += points * 100;
        
        StartCoroutine(ShowMark(sprite));
    }

    private int GetType(float weight) {
        return weight switch {
            <= 50 => 1,
            >= 50 and <= 250 => 2,
            _ => 3
        };
    }

    private IEnumerator ShowMark(Sprite sprite) {
        mark.sprite = sprite;
        mark.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        mark.gameObject.SetActive(false);
    }

    private void OnEnable() {
        OutArea.ItemDispached += HandleItemDispatched;
    }

    private void OnDisable() {
        OutArea.ItemDispached -= HandleItemDispatched;
    }

    public void PlayBadSFX() {
        audioSource.PlayOneShot(incorrectSFX);
    }
}
