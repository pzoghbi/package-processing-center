using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCanvas : MonoBehaviour
{
    TMP_Text tmp;

    private void Awake() {
        tmp = GetComponent<TMP_Text>();
    }

    private void OnScoreChanged(int score) {
        tmp.text = $"SCORE:\n{score}";
    }
    
    private void OnEnable() {
        GameManager.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable() {
        GameManager.ScoreChanged -= OnScoreChanged;
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
